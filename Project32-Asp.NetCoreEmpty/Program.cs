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
Görevi: HTTP isteklerini işlemek ve iş mantığını yürütmek.

ACTION
Görevi: Controller içinde kullanıcıdan gelen istekleri karşılar ve iş mantığını içerir.

MODEL
Görevi: Uygulamanın verilerini temsil eder ve Controller ile View arasında bir köprü görevi görür.

VIEW
Görevi: HTML çıktısını üretir ve kullanıcıya gösterir.

RAZOR
Görevi: Dinamik HTML çıktıları üretmek için C# kodu ile HTML'i birleştirir.

RAZORVIEW
Görevi: Razor ile oluşturulmuş bir .cshtml dosyasını ifade eder.

WWWROOT
Görevi: CSS, JavaScript ve resim gibi statik dosyaları barındırır.

BUİLDER.BUİLD()
Tanım: ASP.NET Core uygulamasını oluşturur ve çalıştırmaya hazır hale getirir.
Amaç:  Uygulamanın yapılandırmalarını tamamlar. Uygulamanın middleware (ara katman) hattını oluşturur.

APP.RUN()
Tanım: ASP.NET Core uygulamasını başlatır ve HTTP isteklerini dinlemeye başlar.
Amaç:  Uygulamanın ana döngüsünü başlatır. Uygulama Run metodu çalışana kadar gelen istekleri işleyemez.

 */