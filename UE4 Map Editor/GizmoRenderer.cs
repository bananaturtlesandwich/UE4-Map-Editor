using GL_EditorFramework;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace UE4MapEditor;
public static class GizmoRenderer
{
    public static ShaderProgram shader;

    static VertexArrayObject plane;

    static readonly float[] vertices =
    {
        -0.5f, -0.5f, 0,
         0.5f, -0.5f, 0,
         0.5f,  0.5f, 0,
        -0.5f,  0.5f, 0,
    };

    static int tex;

    public static void Initialise()
    {
        shader = new(
            new FragmentShader(
                @"#version 330
                uniform sampler2D tex;
                uniform vec4 color;
                in vec2 uv;
                
                void main(){
                    gl_FragColor = color * texture(tex,uv);
                }"),
            new VertexShader(
                @"#version 330
                layout(location = 0) in vec4 position;
                uniform vec2 uvTopLeft;
                uniform mat4 mtxMdl;
                uniform mat4 mtxCam;
                out vec2 uv;
                vec2 map(vec2 value, vec2 min1, vec2 max1, vec2 min2, vec2 max2) {
                    return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
                }
                void main(){
                    uv = map(position.xy,vec2(-0.5,0.5),vec2(0.5,-0.5), uvTopLeft, uvTopLeft+vec2(0.25,0.25));
                    gl_Position = mtxCam*mtxMdl*position;
                }"));
        int buffer = GL.GenBuffer();

        plane = new(buffer);
        plane.AddAttribute(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        plane.Submit();

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        tex = GL.GenTexture();
        var texsheet = Gizmos.Icons;
        var texdata = texsheet.LockBits(new(0, 0, 512, 512), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba32i, 512, 512, 0, PixelFormat.Bgra, PixelType.Int, texdata.Scan0);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        texsheet.UnlockBits(texdata);
    }

    public static bool TryDraw(string classtype, GL_ControlModern control, Pass pass, Vector3 position, Vector4 highlightColor)
    {
        Vector2 TopLeft;

        switch (classtype)
        {
            case "PointLight":
                TopLeft = new(0.25f, 0);
                break;
            default:
                return false;
        }
        if (pass != Pass.OPAQUE)
        {
            control.UpdateModelMatrix(new Matrix4(control.InvertedRotationMatrix) * Matrix4.CreateTranslation(position));

            if (pass == Pass.TRANSPARENT)
            {
                Vector4 color = Vector4.One * (1 - highlightColor.W) + highlightColor * highlightColor.W;

                color.W = 0.8f;

                control.CurrentShader = shader;

                GL.ActiveTexture(TextureUnit.Texture0);
                GL.BindTexture(TextureTarget.Texture2D, tex);

                GL.Enable(EnableCap.Blend);
                GL.Enable(EnableCap.AlphaTest);
                GL.AlphaFunc(AlphaFunction.Gequal, 0.25f);

                shader.SetVector4("color", color);
                shader.SetVector2("uvTopLeft", TopLeft);

                plane.Use(control);
                GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                GL.Disable(EnableCap.Blend);
                GL.Disable(EnableCap.AlphaTest);
            }
            else
            {
                control.CurrentShader = Framework.SolidColorShaderProgram;

                Framework.SolidColorShaderProgram.SetVector4("color", control.NextPickingColor());

                plane.Use(control);
                GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            }
        }

        return true;
    }
}
