using Kyiv;
using Мікрософт.АспНетЯдро.Компоненти.Веб;
using Мікрософт.АспНетЯдро.Компоненти.ВебАсемблі.Хостінг;
using System.Globalization;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

var будівник = БудівникХостаВебАсемблі.СтворитиЗаЗамовчанням(args);
будівник.КорневіКомпоненти.Add<Апка>("#app");
будівник.КорневіКомпоненти.Add<ВіддушинаЗаголовка>("head::after");

будівник.Сервіси.AddScoped(sp => new HttpClient { BaseAddress = new Uri(будівник.ОточенняХоста.BaseAddress) });
будівник.Сервіси.AddSingleton<МашинаКиїв>();
будівник.Сервіси.AddLocalization();

var хазяїн = будівник.Побудувати();
const string культураЗаЗамовчанням = "en-US";

var js = хазяїн.Сервіси.GetRequiredService<IJSRuntime>();
var культураІзНалаштувань = await js.InvokeAsync<string>("blazorCulture.get");
var культура = CultureInfo.GetCultureInfo(культураІзНалаштувань ?? культураЗаЗамовчанням);

if (культураІзНалаштувань == null)
{
    await js.InvokeVoidAsync("blazorCulture.set", культураЗаЗамовчанням);
}

CultureInfo.DefaultThreadCurrentCulture = культура;
CultureInfo.DefaultThreadCurrentUICulture = культура;

await хазяїн.ЗапуститиАсінх();