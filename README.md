## ASP.NET Core MVC Uygulaması

---

## **Proje Hakkında**
Bu proje, bir ASP.NET Core MVC uygulamasıdır ve temel bir MVC yapısının nasıl oluşturulacağını ve yapılandırılacağını göstermektedir. Aşağıda projede kullanılan kavramlar, kod parçalarının açıklamaları ve projenin genel yapısı detaylı olarak açıklanmıştır.

---

## **Proje Yapısı**

- **Controllers**:  
  HTTP isteklerini işleyen ve iş mantığını barındıran sınıflardır.
- **Models**:  
  Veritabanı ve iş mantığı verilerini temsil eder.
- **Views**:  
  Kullanıcıya gösterilecek HTML çıktılarını oluşturur.
- **wwwroot**:  
  Uygulamanın statik dosyalarını (CSS, JS, resim vb.) barındırır.

---

## **Kod Detayları**

### **Başlangıç: Builder ve Servislerin Eklenmesi**
```csharp
var builder = WebApplication.CreateBuilder(args);

// MVC Servislerinin Eklenmesi
builder.Services.AddControllersWithViews();
```
- **Amaç:**  
  Bu satırlar, MVC mimarisinin Controller ve View bileşenlerini uygulamaya dahil eder.
- **Eklenen Servisler:**  
  - Controller: HTTP isteklerini işler.  
  - View: Dinamik HTML çıktıları üretir.  

---

### **Uygulamanın Başlatılması**
```csharp
var app = builder.Build();
```
- **Amaç:**  
  Uygulamayı başlatmak ve HTTP isteklerini işlemek için gerekli yapılandırmaları hazırlar.

---

### **Middleware İşlem Hattı**
```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
```
- **Amaç:**  
  Geliştirme (Development) ortamı dışında özel hata yönetimi sağlanır:
  - `/Home/Error`: Bir hata meydana geldiğinde kullanıcı bu sayfaya yönlendirilir.
  - **HSTS:** HTTPS güvenlik standartlarını etkinleştirir.

```csharp
app.UseHttpsRedirection();
```
- **Amaç:**  
  HTTP isteklerini otomatik olarak HTTPS'e yönlendirerek bağlantı güvenliğini artırır.

```csharp
app.UseStaticFiles();
```
- **Amaç:**  
  `wwwroot` klasöründeki statik dosyaları (CSS, JS, resim vb.) kullanıcıya sunar.

```csharp
app.UseRouting();
```
- **Amaç:**  
  Gelen isteklerin doğru Controller ve Action'a yönlendirilmesi için routing mekanizmasını etkinleştirir.

```csharp
app.UseAuthorization();
```
- **Amaç:**  
  Yetkilendirme gereksinimlerini kontrol eder. (Örn. kullanıcı erişim hakları)

---

### **Routing: Varsayılan Rota Tanımı**
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
- **Amaç:**  
  Gelen HTTP isteğini varsayılan olarak bir Controller ve Action'a yönlendirir.
- **Pattern Açıklaması:**  
  - `{controller=Home}`: Controller ismi belirtilmezse, varsayılan olarak `HomeController` çalışır.  
  - `{action=Index}`: Action ismi belirtilmezse, varsayılan olarak `Index` Action'ı çalışır.  
  - `{id?}`: ID parametresi isteğe bağlıdır.

---

### **Uygulamanın Çalıştırılması**
```csharp
app.Run();
```
- **Amaç:**  
  Uygulamanın ana döngüsünü başlatır ve HTTP isteklerini dinlemeye başlar.

---

## **MVC Kavramları**

### **Controller**
- **Görevi:** HTTP isteklerini işlemek ve iş mantığını yürütmek.  
- **Örnek:**  
  `HomeController` sınıfı, `/Home` isteğini işler ve `Index` gibi Action metotları çağırır.

### **Action**
- **Görevi:**  
  Controller içinde kullanıcıdan gelen istekleri karşılar ve iş mantığını içerir.  
- **Örnek:**  
  `/Home/Index` isteği, `HomeController` içindeki `Index` metodunu çalıştırır.

### **Model**
- **Görevi:**  
  Uygulamanın verilerini temsil eder ve Controller ile View arasında bir köprü görevi görür.  
- **Örnek:**  
  Bir `Product` modeli, bir ürünün adını, fiyatını ve açıklamasını içerir.

### **View**
- **Görevi:**  
  HTML çıktısını üretir ve kullanıcıya gösterir.  
- **Örnek:**  
  `Index.cshtml` dosyası, `HomeController`'ın `Index` metodundan dönen verileri işler.

### **Razor**
- **Görevi:**  
  Dinamik HTML çıktıları üretmek için C# kodu ile HTML'i birleştirir.  
- **Örnek:**  
  ```razor
  <h1>@Model.Name</h1>
  ```

### **wwwroot**
- **Görevi:**  
  CSS, JavaScript ve resim gibi statik dosyaları barındırır.

---

## **Projenin Çalıştırılması**

### **Adım 1: Uygulamayı Başlatın**
1. Proje klasöründe terminali açın.
2. `dotnet run` komutunu çalıştırarak uygulamayı başlatın.

### **Adım 2: Tarayıcıdan Uygulamaya Erişin**
- Tarayıcıda `https://localhost:5001` adresine giderek uygulamayı görüntüleyin.

### **Adım 3: Varsayılan Rota Deneyin**
- `/` → `HomeController`'ın `Index` metodu çalışır.
- `/Home/About` → `HomeController`'ın `About` metodu çalışır.
- `/Products/Details/5` → `ProductsController`'ın `Details` metodu çalışır ve `id` parametresi 5 olur.

---

## **Proje İçeriği**

### **Klasörler**
- **Controllers:** Controller sınıfları.
- **Models:** Veri modelleri.
- **Views:** Razor View dosyaları.
- **wwwroot:** Statik dosyalar.

### **Temel Dosyalar**
- **Program.cs:** Uygulamanın başlangıç noktası.
- **appsettings.json:** Uygulama yapılandırma ayarları.

---

## **Gelecekteki Geliştirmeler**
- Daha karmaşık rotalar eklenebilir.
- Model-View-Controller arasındaki iletişim genişletilebilir.
- Veritabanı bağlantıları ve Entity Framework desteği eklenebilir.
