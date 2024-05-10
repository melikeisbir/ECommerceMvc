using Newtonsoft.Json;

namespace ECommerceMvc.Oturum
{
    public static class SessionOturum //gondermiş oldugum bilgileri tutsun
                               //json formatına atayıp bilgiyi ordan almak
    {
        public static void SetJson(this ISession session, string key, object value) //gelen veriyi anhatar ve obje olarak session içine al
        {
            session.SetString(key, JsonConvert.SerializeObject(value)); //veriyi json formatına çevir
        }
        public static T GetJson<T>(ISession session, string key) //saklanann veriyi kullanabilmek için
        { //veriyi T tipinde içeriye al
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T):JsonConvert.DeserializeObject<T>(sessionData);//boşsa veriyi geri gönder boş değilse objeyi nesne olarak dondur
        }
    }
}
