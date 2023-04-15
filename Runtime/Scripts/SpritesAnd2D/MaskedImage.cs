using UnityEngine;
using UnityEngine.UI;

namespace TheAshenWolfLib.Runtime.Scripts.SpritesAnd2D
{
    public class MaskedImage : Image
    {
        private static readonly int _stencilComp = Shader.PropertyToID("_StencilComp");

        public override Material materialForRendering
        {
            get
            {
                Material mat = new Material(base.materialForRendering);
                mat.SetInt(_stencilComp, (int)UnityEngine.Rendering.CompareFunction.NotEqual);
                return mat;
            }
        }
    
    }
}
