// Lesson 7.1 Introduction to DSLs
// A DSL can be valuable in several situations. For instance, let's consider a DSL we could write that would
// allow non programmers to be able to write simple scripts to generate reports on patient info.
// We know the data we need about the patient, their weight etc., so we could develop a way for the user to write
// something like : get all field weight < and then it would return each patient with their weight.
// We could expand this as much as we like to match any field or do more complicated expressions.
// This syntax is very similar to SQL, which is a high level language. A DSL is a high level language but, it
// is more specified to a specific domain, so that the user using it will know the business language.
type BloodType =
    | A
    | B
    | O

type Patient =
    { FirstName: string
      LastName: string
      Age: int
      // Height in meters.
      Height: double
      // Weight in kilograms.
      Weight: double
      BloodType: BloodType }

// Lesson 7.2 Creating Simple DSLs
// The simplest DSL is to use the basic language features already available.
type PatientData =
    | FirstName
    | LastName
    | Age
    | Height
    | Weight
    | BloodType
    
type PatientDataWithData =
    | FirstName of string
    | LastName of string
    | Age of int
    | Height of double
    | Weight of double
    | BloodType of BloodType

type Amount =
    | All
    | Amount of int

type PatientReport =
    | Get

let getAllFromPatients (patientData: PatientData) patients: PatientDataWithData seq =
   match patientData with
   | PatientData.FirstName -> patients |> Seq.map (fun patient -> FirstName patient.FirstName)
   | PatientData.LastName -> patients |> Seq.map (fun patient -> LastName patient.LastName)
   | PatientData.Age -> patients |> Seq.map (fun patient -> Age patient.Age)
   | PatientData.Height -> patients |> Seq.map (fun patient -> Height patient.Height)
   | PatientData.Weight -> patients |> Seq.map (fun patient -> Weight patient.Weight)
   | PatientData.BloodType -> patients |> Seq.map (fun patient -> BloodType patient.BloodType)

let getAmountFromPatients amount (patientData: PatientData) patients: PatientDataWithData seq =
    match patientData with
    | PatientData.FirstName -> patients |> Seq.take amount |> Seq.map (fun patient -> FirstName patient.FirstName)
    | PatientData.LastName -> patients |> Seq.take amount |> Seq.map (fun patient -> LastName patient.LastName)
    | PatientData.Age -> patients |> Seq.take amount |> Seq.map (fun patient -> Age patient.Age)
    | PatientData.Height -> patients |> Seq.take amount |> Seq.map (fun patient -> Height patient.Height)
    | PatientData.Weight -> patients |> Seq.take amount |> Seq.map (fun patient -> Weight patient.Weight)
    | PatientData.BloodType -> patients |> Seq.take amount |> Seq.map (fun patient -> BloodType patient.BloodType)
    
let createReport (report: PatientReport) (amount: Amount) (patientData: PatientData) patients =
    match report with
    | Get ->
        match amount with
        | All -> getAllFromPatients patientData patients
        | Amount count ->  getAmountFromPatients count patientData patients

let ted = {
    FirstName = "Ted"
    LastName = "Tedson"
    Age = 33
    Height = 1.9
    Weight = 95.0
    BloodType = A 
}

let john = {
    FirstName = "John"
    LastName = "Johnson"
    Age = 44
    Height = 1.95 
    Weight = 100.0
    BloodType = B
}

let patients = seq [john; ted]
// Now we can take this function and expose it like so:
// Now to create the report they just need to remember "createReport", and a few other commands that we can match on.
let getAllWeights = createReport Get All PatientData.Weight patients
// val it: PatientDataWithData seq = seq [Weight 100.0; Weight 95.0] < We will get this result which is very helpful.
// We can pull out any more info that we want, we could attach the weight to the patient in a tuple or anything else.
// Let's look at how we can use active patterns next to help us make this even simpler.
// Exercise 7.2
// Create a report that gets all the patients ages.

// Lesson 7.3 Using Active Patterns

// Lesson 7.4 Computation Expressions

// Lesson 7.5 Type Providers for DSLs
