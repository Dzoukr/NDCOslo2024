module NDCOslo2024.Server.Definition1

open NDCOslo2024.Shared.Definition
open NDCOslo2024.Server.Builders

let header =
    area {
        name "header"
        panels [
            placeholderPanel {
                width (Px 4)
                height (Px 64)
                backgroundColor "#D72622"
            }
            placeholderPanel {
                width (Px 4)
                height (Px 64)
                backgroundColor "#D72622"
            }
        ]
    }

let main =
    area {
        name "main"
        panels [
            placeholderPanel {
                width (Px 100)
                height (Px 100)
                backgroundColor "pink"
            }
        ]
    }

let sideRight =
    area {
        name "sideRight"
        panels [
            callQueuePanel {
                maxCalls 8
            }
            placeholderPanel {
                width (Px 100)
                height (Px 100)
                backgroundColor "yellow"
            }
        ]
    }


let configuration1 =
    definition {
        width (Px 1920)
        height (Px 1080)
        columns [
            Px 188
            Px 1444
            Px 280
        ]
        rows [
            Px 64
            Px 184
            Px 752
            Auto
        ]
        layout [
            "header header header"
            "sndRow sndRow sndRow"
            "sideLeft main sideRight"
            "footer footer footer"
        ]
        areas [
            header
            main
            sideRight
        ]
    }