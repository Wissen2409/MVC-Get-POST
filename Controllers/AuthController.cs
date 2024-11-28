using Microsoft.AspNetCore.Mvc;

public class AuthController:Controller{

    [HttpGet]
    public IActionResult SaveUser(){

        return View();

    }
    [HttpPost]
    public IActionResult SaveUser(SaveUserViewModel model){

        // Parametre olarak gelen model içerisinde sayfadan girilen verileri alabilirsiniz!!!

        // bu verileri aldıktan sonra, isterseniz veri tabanına kaydedebilirsiniz!!!!

        // Eski yöntem ile veri tabanı bağlantısı
        return View();

    }

}