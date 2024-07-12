module EHRServer.Endpoints

open Giraffe
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging

type Patient =
    { FirstName: string
      LastName: string
      Age: int
      Height: double
      Weight: double }

let testPatients =
    [| { FirstName = "Ted"
         LastName = "Tedson"
         Age = 23
         Height = 1.8
         Weight = 100 } |]

let getPatients (logger: ILogger) =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            logger.LogInformation("Handling GET /patients request")
            return! json testPatients next ctx
        }
