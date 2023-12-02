open Avalonia


type MainWindow() as this = 
    inherit Controls.Window()

    do this.InitializeComponent()

    member private this.InitializeComponent() =
        Markup.Xaml.AvaloniaXamlLoader.Load(this)


type App() =
    inherit Application()

    override x.OnFrameworkInitializationCompleted() =
        match x.ApplicationLifetime with
        | :? Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime 
            as desktop ->
            desktop.MainWindow <- new MainWindow()
        | _ -> ()

        base.OnFrameworkInitializationCompleted()



[<CompiledName "BuildAvaloniaApp">] 
let buildAvaloniaApp () = 
    AppBuilder
        .Configure<App>()
        .UsePlatformDetect()
        
 
 
// pretty standard console app F# with calling the 
// program execution start as main and passing in
// any arguments 
// so one did >myProgram.exe --help
// that --help would be the argument and available 
// from the 'argv' string array
[<EntryPoint; System.STAThread>]  //these are dotnet things
let main argv =
    buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
