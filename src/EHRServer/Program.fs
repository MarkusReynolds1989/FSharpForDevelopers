module EHRServer.Main

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

let webApp (logger: ILogger) =
    choose
        [ GET >=> choose [ route "/" >=> Endpoints.getPatients logger ]
          POST >=> choose [ route "/fake" >=> text "I'm a snake." ] ]

let configureApp (app: IApplicationBuilder) =
    let logger =
        app.ApplicationServices.GetRequiredService(typeof<ILogger<obj>>) :?> ILogger

    app.UseGiraffe(webApp logger)

let configureServices (services: IServiceCollection) = services.AddGiraffe() |> ignore

let configureLogger (loggingBuilder: ILoggingBuilder) = loggingBuilder.AddConsole() |> ignore

[<EntryPoint>]
let main _ =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun webHostBuilder ->
            webHostBuilder
                .Configure(configureApp)
                .ConfigureServices(configureServices)
                .ConfigureLogging(configureLogger)
            |> ignore)
        .Build()
        .Run()

    0
