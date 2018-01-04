using System.Drawing;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProfileImage image = new ProfileImage();

            image.Image1 = GenerateImage.GetDefaultBase64Image("Abhimanyu", new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold), Color.White, Color.Green, 50, 50);
            image.Image2 = GenerateImage.GetDefaultBase64Image("Nisha", new Font(FontFamily.GenericSansSerif, 25.0F, FontStyle.Bold), Color.White, Color.Green, 100, 100);
            image.Image3 = GenerateImage.GetDefaultBase64Image("Ganesh", new Font(FontFamily.GenericSansSerif, 35.0F, FontStyle.Bold), Color.White, Color.Green, 150, 150);
            image.Image4 = GenerateImage.GetDefaultBase64Image("Ramesh", new Font(FontFamily.GenericSansSerif, 50.0F, FontStyle.Bold), Color.White, Color.Green, 200, 200);

            return View(image);
        }
    }
}