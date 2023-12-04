// For more information see https://aka.ms/fsharp-console-apps

open fsharp_workflow_patterns

Workflow2.executeWorkflow {
    EmailAddress = "test"
    PhoneNumber = "test" 
} |> ignore