using DAL;

namespace WebApp.Core
{
    public static class Extensions
    {
        public static string ToUrl(this GetAgroProducts_Result product)
        {
            return "/agro/" + product.product_name.Replace(' ', '_') + "/" + product.id;
        }
        public static string ToImagePath(this string image, string defaultPath = "")
        {
            return image == null ? defaultPath : "/resource/images/product/" + image;
        }
        public static string ToImagePathFirstImage(this GetAgroProductById_Result product, string defaultPath = "")
        {
            return product.Images == null || product.Images.Length == 0 ? defaultPath : "/resource/images/product/" + product.Images[0];
        }
    }
}