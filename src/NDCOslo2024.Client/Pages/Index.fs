module NDCOslo2024.Client.Pages.Index

open Feliz
open Feliz.DaisyUI
open Elmish
open NDCOslo2024.Client.Server
open Feliz.UseElmish
open NDCOslo2024.Shared.Definition

type private State = {
    Definition : Definition option
}

type private Msg =
    | LoadDefinition
    | DefinitionLoaded of ServerResult<Definition>

let private init () = { Definition = None }, Cmd.ofMsg LoadDefinition

let private update (msg:Msg) (state:State) : State * Cmd<Msg> =
    match msg with
    | LoadDefinition -> state, Cmd.OfAsync.eitherAsResult (fun _ -> service.GetDefinition()) DefinitionLoaded
    | DefinitionLoaded (Ok def) -> { state with Definition = Some def }, Cmd.none

[<ReactComponent>]
let IndexView () =
    let state, dispatch = React.useElmish(init, update, [| |])

    React.fragment [
        Html.div (string state.Definition)

    ]

