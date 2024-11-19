var builder = WebApplication.CreateBuilder(args);

// Bu satır, MVC uygulamasında Controller ve View desteğini etkinleştirmek için gerekli servisleri ekler.
// Controller'lar, kullanıcı isteklerini işler; View'ler ise dinamik HTML çıktıları üretir.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP isteği alındığında hangi işlemlerin yapılacağını tanımlayan bir işlem hattı oluşturuyoruz.
// Geliştirme (Development) ortamı dışında çalışıyorsak özel hata işleme yapılandırması.
if (!app.Environment.IsDevelopment())
{
    // Hata yönetimi: Uygulama bir hata alırsa kullanıcıyı "/Home/Error" sayfasına yönlendirir.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTP isteklerini otomatik olarak HTTPS'e yönlendirir. Bu, güvenli bir bağlantı sağlar.
app.UseHttpsRedirection();


// Statik dosyaların sunulması
// wwwroot klasöründeki CSS, JavaScript, resim gibi statik dosyaların tarayıcıya sunulmasını sağlar.
app.UseStaticFiles();


// Routing'in etkinleştirilmesi
// Gelen isteklerin doğru Controller ve Action'a yönlendirilmesini sağlamak için kullanılır.
app.UseRouting();


// Kullanıcıların belirli kaynaklara erişimi için yetkilendirme işlemlerini kontrol eder.
app.UseAuthorization();

// "{controller=Home}" → Controller ismi varsayılan olarak Home'dur.
// "{action=Index}" → Action ismi varsayılan olarak Index'tir.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Bu noktadan sonra uygulama çalışmaya hazırdır.
app.Run();



/*
 KAVRAMLAR VE METOTLAR AÇIKLAMASI
CONTROLLER
Tanım:Kullanıcının HTTP isteğini işleyen ve iş mantığını çalıştıran bir sınıftır.
Amaç: İstekleri (örneğin, bir web tarayıcısından gelen GET veya POST) alır ve gerekli işlemleri yapar.
      Gerekli verileri Model ile alır ve View'e iletir.

ACTION
Tanım:Bir Controller içindeki metotlardan biridir ve iş mantığını içerir.
Amaç: Kullanıcının isteğine göre bir işlemi yürütür.
      Genellikle bir View döndürür, ancak bazen sadece JSON veya metin gibi farklı türde sonuçlar da dönebilir.

MODEL
Tanım: Uygulamada kullanılan veriyi temsil eden sınıftır.
Amaç:  Veritabanından veya başka kaynaklardan alınan veriyi işler ve Controller'a sunar.
       Ayrıca kullanıcıdan alınan veriyi doğrulama işlemleri yapar.

VIEW
Tanım: Kullanıcıya gösterilecek HTML çıktısını üreten bir şablondur.
Amaç:  Controller tarafından sağlanan verileri işleyerek HTML çıktısı oluşturur.
       Kullanıcı arayüzü bu dosyalar üzerinden oluşturulur.

RAZOR
Tanım: ASP.NET Core'da View'ler için kullanılan bir şablon motorudur.
Amaç:  HTML ve C# kodlarını birleştirerek dinamik HTML çıktısı üretir.
       @ sembolüyle başlayan C# ifadelerini kullanır.

RAZORVIEW
Tanım: Razor ile oluşturulmuş bir .cshtml dosyasını ifade eder.
Amaç:  Razor syntax ile yazılmış dinamik HTML sayfalarını temsil eder.
       RazorViewEngine tarafından çalıştırılır ve kullanıcıya sunulur.


WWWROOT
Tanım: Uygulamanın statik dosyalarının (CSS, JS, resim vb.) barındırıldığı özel bir klasördür.
Amaç:  Kullanıcıya direkt olarak erişilebilecek statik dosyaları tutar.


BUİLDER.BUİLD()
Tanım: ASP.NET Core uygulamasını oluşturur ve çalıştırmaya hazır hale getirir.
Amaç:  Uygulamanın yapılandırmalarını tamamlar (örneğin, servislerin eklenmesi).
       Uygulamanın middleware (ara katman) hattını oluşturur.

APP.RUN()
Tanım: ASP.NET Core uygulamasını başlatır ve HTTP isteklerini dinlemeye başlar.
Amaç:  Uygulamanın ana döngüsünü başlatır.
       Uygulama Run metodu çalışana kadar gelen istekleri işleyemez.

 */