// using System.Drawing;
// using System.Drawing.Drawing2D;
// using System.Drawing.Imaging;
// //using System.Drawing;

// public class ImageWatermark{
// 	public void AddTextWatermark(
// 		string imagePath
// 		, string watermarkText
// 		, string outputPath
// 		, string fontName = "Arial"
// 		, int fontSize = 16
// 		, Color fontColor = default(Color)
// 		, int xOffset = 10
// 		, int yOffset = 10
// 	){
// 		if (fontColor == default(Color)) fontColor = Color.White; // 默认白色

// 		using (Image image = Image.FromFile(imagePath))
// 		using (Graphics graphics = Graphics.FromImage(image))
// 		using (Font font = new Font(fontName, fontSize))
// 		using (Brush brush = new SolidBrush(fontColor)){
// 			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
// 			graphics.SmoothingMode = SmoothingMode.HighQuality;
// 			graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

// 			SizeF size = graphics.MeasureString(watermarkText, font);
// 			int x = xOffset;
// 			int y = yOffset;

// 			graphics.DrawString(watermarkText, font, brush, x, y);
// 			image.Save(outputPath, ImageFormat.Jpeg); // 或其他格式
// 		}
// 	}
// }