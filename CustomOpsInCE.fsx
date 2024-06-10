type InputKind =
    | Text of placeholder:string option
    | Password of placeholder: string option

type Input = {
    Label: string option
    Kind : InputKind
}

type InputBuilder() =
    [<CustomOperation("text")>]
    member this.Text(io,?placeholder) =
        { io with Kind = Text placeholder }

    [<CustomOperation("password")>]
    member this.Password(io,?placeholder) =
        { io with Kind = Password placeholder }

    [<CustomOperation("label")>]
    member this.Label(io,label) =
        { io with Label = Some label }

    member t.Yield(_) = {
        Label = None
        Kind = Text None
    }

let input = InputBuilder()

input {
    text "Hi NDC Oslo"
    label "So much Label, wow"
}