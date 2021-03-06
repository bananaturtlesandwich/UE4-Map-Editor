using GL_EditorFramework;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace UE4MapEditor;
public static class GizmoRenderer
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static ShaderProgram shader;

    static VertexArrayObject plane;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
                uniform vec4 colour;
                in vec2 uv;
                
                void main(){
                    gl_FragColor = colour * texture(tex,uv);
                }"),
            new VertexShader(
                @"#version 330
                layout(location = 0) in vec4 position;
                uniform vec2 TopLeft;
                uniform mat4 mtxMdl;
                uniform mat4 mtxCam;
                out vec2 uv;
                vec2 map(vec2 value, vec2 min1, vec2 max1, vec2 min2, vec2 max2) {
                    return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
                }
                void main(){
                    uv = map(position.xy,vec2(-0.5,0.5),vec2(0.5,-0.5), TopLeft, TopLeft+vec2(0.5,0.5));
                    gl_Position = mtxCam*mtxMdl*position;
                }"));

        plane = new(GL.GenBuffer());
        plane.AddAttribute(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        plane.Submit();

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        tex = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, tex);
        Bitmap data = Properties.Resources.icons;
        BitmapData rawdata = data.LockBits(new(0, 0, 256, 256), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 256, 256, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, rawdata.Scan0);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        data.UnlockBits(rawdata);
    }

    public static void Draw(Vector2 TopLeft, GL_ControlModern control, Pass pass, Vector3 position, Vector4 highlightColor)
    {
        if (pass == Pass.OPAQUE) return;

        control.UpdateModelMatrix(new Matrix4(control.InvertedRotationMatrix) * Matrix4.CreateTranslation(position));

        if (pass == Pass.PICKING)
        {
            control.CurrentShader = Framework.SolidColorShaderProgram;

            Framework.SolidColorShaderProgram.SetVector4("colour", control.NextPickingColor());

            plane.Use(control);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
        }
        Vector4 colour = Vector4.One * (1 - highlightColor.W) + highlightColor * highlightColor.W;

        colour.W = 0.8f;

        control.CurrentShader = shader;

        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, tex);

        GL.Enable(EnableCap.Blend);
        GL.Enable(EnableCap.AlphaTest);
        GL.AlphaFunc(AlphaFunction.Gequal, 0.25f);

        shader.SetVector4("colour", colour);
        shader.SetVector2("TopLeft", TopLeft);

        plane.Use(control);
        GL.DrawArrays(PrimitiveType.Quads, 0, 4);
        GL.Disable(EnableCap.Blend);
        GL.Disable(EnableCap.AlphaTest);
        return;
    }
}
