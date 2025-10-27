using web_app.Services;

var builder = WebApplication.CreateBuilder(args);

// add mvc controllers etc
builder.Services.AddControllersWithViews();

// register keyword extractor service so controllers can use it
builder.Services.AddSingleton<IKeywordService, KeywordService>();

// world series data loader (kaggle snapshot) --> will learn how to use kagglehub
builder.Services.AddSingleton<WorldSeriesService>();

var app = builder.Build();

// basic prod vs dev setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // default hsts is 30 days. you can change this later if you want
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// map api routes like /api/keywords/extract
app.MapControllers();

// anything not /api/... falls back to react (index.html)
app.MapFallbackToFile("index.html");

app.Run();
