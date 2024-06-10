module NDCOslo2024.Server.WebApp

open Giraffe
open Giraffe.GoodRead
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Microsoft.Extensions.Logging
open NDCOslo2024.Shared.API
open NDCOslo2024.Shared.Errors

let service = {
    GetDefinition = fun _ -> NDCOslo2024.Server.Definition1.configuration1 |> async.Return
}

let webApp : HttpHandler =
    let remoting logger =
        Remoting.createApi()
        |> Remoting.withRouteBuilder Service.RouteBuilder
        |> Remoting.fromValue service
        |> Remoting.withErrorHandler (Remoting.errorHandler logger)
        |> Remoting.buildHttpHandler
    choose [
        Require.services<ILogger<_>> remoting
        htmlFile "public/index.html"
    ]