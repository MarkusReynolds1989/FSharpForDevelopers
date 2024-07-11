module EHRServer.Endpoints

open Giraffe
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging

let getPatients (logger: ILogger) =
    fun (next: HttpFunc) (ctx: HttpContext) -> task {
        logger.LogInformation("Handling GET /patients request") 
        return! text "none" next ctx
    }
