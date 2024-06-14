module NDCOslo2024.Client.Pages.ElmishExample

open Feliz
open Feliz.DaisyUI
open Elmish
open NDCOslo2024.Client.Server
open NDCOslo2024.Client.Renderers
open Feliz.UseElmish
open NDCOslo2024.Shared.Definition

type private State = {
    Count : int
}

type private Msg =
    | Increase
    | Decrease

let private init () =
    { Count = 0 }, Cmd.none

let private update (msg:Msg) (state:State) : State * Cmd<Msg> =
    match msg with
    | Increase -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrease -> { state with Count = state.Count - 1 }, Cmd.none

[<ReactComponent>]
let ElmishExampleView () =
    let state, dispatch = React.useElmish(init, update, [| |])

    Html.div [
        Daisy.button.div [
            prop.text "Increase"
            prop.onClick (fun _ -> Increase |> dispatch)

        ]
        Daisy.button.div [
            prop.text "Decrease"
            prop.onClick (fun _ -> Decrease |> dispatch)
        ]
        Html.div [
            prop.className "p-4 text-5xl"
            prop.text state.Count
        ]
    ]
