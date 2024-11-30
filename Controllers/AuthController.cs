using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class AuthController : Controller
{

    [HttpGet]
    public IActionResult SaveUser()
    {
        //jhjhjh
        return View();

    }
    [HttpPost]
    public IActionResult SaveUser(SaveUserViewModel model)
    {

        // Parametre olarak gelen model içerisinde sayfadan girilen verileri alabilirsiniz!!!

        // bu verileri aldıktan sonra, isterseniz veri tabanına kaydedebilirsiniz!!!!

        // Eski yöntem ile veri tabanı bağlantısı


        // veri geldikten sonra veri işlenip başarılı şekilde işlenirse, ekranda bunu gösterelim!!!

        // veri tabanına kaydettikten sonra, işlem başarılı ise, ekranda işlem başarılı yazmak için mode içerisindeki isok alanını true olarak işaretleyelim 


        // veri tabanına kayıt işlemi !!!

        SqlConnection con = new SqlConnection("Server=db4856.public.databaseasp.net; Database=db4856; User Id=db4856; Password=Ni4!7@wA-E2r; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True; ");
        SqlCommand cmd = new SqlCommand("insert into UserSave (Name,Email,Password) values (@name,@email,@password)", con);
        cmd.Parameters.AddWithValue("@name", model.Name);
        cmd.Parameters.AddWithValue("@email", model.Email);
        cmd.Parameters.AddWithValue("@password", model.Password);
        con.Open();
        // veri tabanına veriyi kaydedelim!!
        var value = cmd.ExecuteNonQuery();
        // veri kaydedildi!!
        SaveUserViewModel returnModel = new SaveUserViewModel();
        if (value == 1)
        {
            // veri tabanına kayıt yaptıktan sonra, value değeri 1 ise, veri tabanına kayıt başarılı demektir!! 
            // bizde view'da başarılı yazısı çıkartmak için model içerisinde isok alanına true değer basıyoruz!!
            returnModel.IsOk = true;
            // kullanıcı başarılı şekilde kaydedildikten sonra!! farklı bir action'a kullanıyı yönlendirebilirim!!
        }
        return View(returnModel);
    }
    // login için öncelikle bir get sayfası action'u yazalım 

    [HttpGet]
    public IActionResult Login()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {

        // veri tabanı bağlantısı ile ,ekrandan gönderilen değerlerin veri tabanında olup olmadığını kontrol edelim!!
        SqlConnection con = new SqlConnection("Server=db4856.public.databaseasp.net; Database=db4856; User Id=db4856; Password=Ni4!7@wA-E2r; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True; ");
        SqlCommand cmd = new SqlCommand("select Count(Name) from UserSave where Email=@email and Password=@password", con);
        cmd.Parameters.AddWithValue("@email", model.Email);
        cmd.Parameters.AddWithValue("@password", model.Password);
        con.Open();
        var returnValue = Convert.ToInt32(cmd.ExecuteScalar());
        if (returnValue == 1)
        {

            // siz herhangi bir action!'dan farklı bir view açabilirsiniz!!

            // login işleminde, gönderilen login doğru ise, farklı bir view'a yönlenelim, doğru değilse, yine login view'i açılsın!!
            WelComeViewModel returnModel = new WelComeViewModel(){ Email=model.Email};

            return View("Welcome", returnModel);
        }
        return View();
    }
}