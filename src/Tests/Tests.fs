module Tests

open System
open System.Net
open System.Net.Http
open EHRServer
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Testing
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Xunit
open Giraffe

[<Fact>]
let ``My test`` () = Assert.Equal(1, 1)
