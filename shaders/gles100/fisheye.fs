#version 100

precision mediump float;

varying vec2 fragTexCoord;

uniform sampler2D texture0;
uniform vec4 tintColor;

// NOTE: Add here your custom variables 

const float PI = 3.1415926535;

void main()
{
    float aperture = 178.0f;
    float apertureHalf = 0.5 * aperture * (PI / 180.0);
    float maxFactor = sin(apertureHalf);

    vec2 uv = vec2(0);
    vec2 xy = 2.0 * fragTexCoord.xy - 1.0;
    float d = length(xy);
    
    if (d < (2.0 - maxFactor))
    {
        d = length(xy * maxFactor);
        float z = sqrt(1.0 - d * d);
        float r = atan(d, z) / PI;
        float phi = atan(xy.y, xy.x);

        uv.x = r * cos(phi) + 0.5;
        uv.y = r * sin(phi) + 0.5;
    }
    else
    {
        uv = fragTexCoord.xy;
    }

    gl_FragColor = texture2D(texture0, uv);
}