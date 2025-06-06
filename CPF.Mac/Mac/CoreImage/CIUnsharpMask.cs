using CPF.Mac.ObjCRuntime;
using System;

namespace CPF.Mac.CoreImage
{
	[Since(6, 0)]
	public class CIUnsharpMask : CIFilter
	{
		public CIImage Image
		{
			get
			{
				return GetInputImage();
			}
			set
			{
				SetInputImage(value);
			}
		}

		public float Intensity
		{
			get
			{
				return GetFloat("inputIntensity");
			}
			set
			{
				SetFloat("inputIntensity", value);
			}
		}

		public float Radius
		{
			get
			{
				return GetFloat("inputRadius");
			}
			set
			{
				SetFloat("inputRadius", value);
			}
		}

		public CIUnsharpMask()
			: base("CIUnsharpMask")
		{
		}

		public CIUnsharpMask(IntPtr handle)
			: base(handle)
		{
		}
	}
}
