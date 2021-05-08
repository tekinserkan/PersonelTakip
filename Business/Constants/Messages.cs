using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid= "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string ProductListed="Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün eklenebilir";
        public static string ProductNameAlreadyExits = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Categori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı Bulunumadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı adı mevcut. Tekrar deneyiniz";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string UserNameAlreadyExits = "Bu isimde başka bir kullanıcı var";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi"; 
        public static string UserPasswordError = "Hatalı parola. Tekrar deneyiniz";
        public static string UserNameError = "Kullanıcı adı hatalı. Tekrar deneyiniz";

    }
}
