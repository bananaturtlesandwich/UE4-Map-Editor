﻿using GL_EditorFramework;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace UE4MapEditor;

public static class GizmoRenderer
{
    public static VertexArrayObject Plane;

    public static int Icons;

    public static ShaderProgram DefaultShaderProgram;

    static bool Initialised = false;

    public static void Initialize()
    {
        if (Initialised) return;
        var defaultFrag = new FragmentShader(
            @"#version 330
            uniform sampler2D tex;
            uniform vec4 color;
            in vec2 uv;
                
            void main(){
                gl_FragColor = color * texture(tex,uv);
            }");
        var defaultVert = new VertexShader(
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
            }");
        DefaultShaderProgram = new ShaderProgram(defaultFrag, defaultVert);

        int buffer;

        #region block
        buffer = GL.GenBuffer();

        Plane = new VertexArrayObject(buffer);
        Plane.AddAttribute(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
        Plane.Submit();

        float[] data = new float[]
        {
            -0.5f, -0.5f, 0,
             0.5f, -0.5f, 0,
             0.5f,  0.5f, 0,
            -0.5f,  0.5f, 0,
        };

        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * data.Length, data, BufferUsageHint.StaticDraw);
        #endregion

        //texture sheet
        Icons = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, Icons);

        var bmp = Gizmos.Icons;
        var bmpData = bmp.LockBits(
            new Rectangle(0, 0, 128 * 4, 128 * 4),
            System.Drawing.Imaging.ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 128 * 4, 128 * 4, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        bmp.UnlockBits(bmpData);
        Initialised = true;
    }

    public static bool TryDraw(string classtype, GL_ControlModern control, Pass pass, Vector3 position, Vector4 highlightColor)
    {
        Vector2 uvTopLeft;

        switch (classtype)
        {
            case "PointLight":
            case "SpotLight":
                uvTopLeft = new(0.25f, 0);
                break;
            case "CameraActor":
                uvTopLeft = new(0, 0);
                break;
            case "AkComponent":
                uvTopLeft = new(0, 0.25f);
                break;
            default: return false;
        }
        if (pass == Pass.OPAQUE) return true;
        control.UpdateModelMatrix(new Matrix4(control.InvertedRotationMatrix) * Matrix4.CreateTranslation(position));

        if (pass == Pass.TRANSPARENT)
        {
            Vector4 color = Vector4.One * (1 - highlightColor.W) + highlightColor * highlightColor.W;

            color.W = 0.8f;

            control.CurrentShader = DefaultShaderProgram;

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Icons);

            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.25f);

            DefaultShaderProgram.SetVector4("color", color);
            DefaultShaderProgram.SetVector2("uvTopLeft", uvTopLeft);

            Plane.Use(control);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.AlphaTest);
        }
        else
        {
            control.CurrentShader = Framework.SolidColorShaderProgram;

            Framework.SolidColorShaderProgram.SetVector4("color", control.NextPickingColor());

            Plane.Use(control);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
        }

        return true;
    }
}