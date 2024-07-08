// Lesson 3.1 Tuples and Records
// We looked at tuples before, but let's do a refresher on them.
// Let's say we want to make a patient named John so we create all his information:

let john = "John", "Johnson", 23, 95.0, 1.9
// The parts of the tuple here, separated by commas, are FirstName, LastName, Age, Weight, and Height.
// How do I get the individual pieces of the tuple? There's a couple ways.
let johnFirstName, johnLastName, johnAge, johnWeight, johnHeight = john
// We can "destructure" the tuple into individual variables like so.
// Alternatively, we can use a tuple shorthand. The tuple shorthand is fst and snd, but they only work for tuples with
// only two values so not relevant to our use.

// What would I do if I wanted to create another patient? What would the collection to hold all the patients
// look like? If we think about it from a scale standpoint, this will be way too much work to keep track of.
// It would be much easier to have a specialized data type for a patient.

// Records are the way the programmer can create their own types. We've seen built in types so far, string
// ints, and so on, but we may need a more robust and specialized data type.
// Let's create a record for a patient.
type Patient =
    { FirstName: string
      LastName: string
      Age: int
      // In kilograms.
      Weight: double
      // In meters.
      Height: double }
// Now we have the shape of the data needed to create a patient, let's go ahead and create one.
let ted =
    { FirstName = "Ted"
      LastName = "Tedson"
      Age = 45
      Weight = 100.0
      Height = 1.8 }
// Now we have a patient, imagine if we had to individually track each individual part of that, it would have been
// really annoying and time-consuming to remember each variable that associated to Ted.
// I can pack up many patients into a collection without any issues.
let patients = seq [ ted ]
// Now we have a seq of patients instead of individual patients. Remember that F# is strongly typed, we didn't tell
// it what the type of the seq should be but, it was able to discern it itself.
// Exercise 3.1
// Create another patient and load it into the patients sequence by using Seq.append.

// Lesson 3.2 Discriminated Unions
// We've talked about records which are a powerful user defined type, but there is also another very
// powerful user defined type that can help us in other ways. Supposed that we need to use a bool (true or false) value
// for something. Many would agree that true and false are not very descriptive for things like flags, so what
// are our options? We can use a discriminated union.
type BloodType =
    | A
    | B
    | O
// I want my patients to have a blood type associated with them, so I can add in a discriminated union of the options.
// Suppose Ted has a blood type of A, what we can do now is set up a match against the DU of his blood type to
// take different actions depending on his blood type.
let tedsBloodType = A
// Again, I didn't have to tell it the type, it was able to infer.
// You can be explicit though.
let johnsBloodType: BloodType = B

match tedsBloodType with
| A -> printfn "Starting A blood type transfusion."
| B
| O -> printfn "Shutting down, critical error, wrong blood type."
// Notice that B and O do the same thing when they are matched, that is safer than adding
// a _ wildcard to handle anything else.
// Discriminated unions are also powerful enough to be used as a sort of record type as well, or to hold more
// sophisticated types of data.
// Supposed we wanted to add a note to go along with the blood type for some reason.
type DUBloodType =
    | A of string
    | B of string
    | O of string

let tedsBloodTypeDU = A "Ted's blood is A."

match tedsBloodTypeDU with
// Notice that now when we match we put in a name for the extra item, so we can use it in the match branch.
| A note -> printfn $"{note}"
// Notice we discard the extra info here using the wildcard _ symbol.
| B _
| O _ -> printfn "Shutting down, critical error, wrong blood type."

// Exercise 3.2
// Create a DU for a feature flag on a program. The user should be able to turn it on or off, if it is off
// it has no value, if it is on it will take an integer. The feature is for how many tabs can be open at once.

// Lesson 3.3 Option Types
// Let's transition into another powerful type that is used a great deal in F# and progresses nicely from DUs, as it
// is a DU.
// The option type is a built-in type in F# that helps us to avoid things like having a null value.
// Consider the situation where we need to get some info from the user but, we haven't got it yet.
// In other languages, we would leave the string as null or an empty string until the user puts in the info.
// In F#, we have a type specially for situations where we might have some data or no data.
let mutable userInput = None
// In this case, we have no data, and we also don't know what the data would resolve to if it was Some.
userInput <- Some "Ted"
// Now I've got the user input, I am going to mutate the username to "some" data. It's not none anymore.
// I can match on an option type:
match userInput with
| None -> printfn "Please put in your name."
| Some name -> printfn $"Thank you {name}."
// Now we cannot run into a null value. We are considering every possible
// condition of the data, whether it exists or not.
// I will show you how we could get a null reference exception.
let mutable johnName: string = null
// I have a string but it has a null value, what will happen if I try to use it?
johnName.ToCharArray() |> ignore
// I can't use it because it's null! I get a null reference exception!
// This would never have happened if I was using the option type:
userInput <- None
// See, the string value isn't exposed so, I can't do anything with it.
// I can use value which is dangerous and could lead to an exception, but that's it. The normal pattern is to match
// instead of directly unwrap so, it would be a code smell anyway.

// Exercise 3.3
// Write an option type for the blood type from above. Maybe we don't know the blood type yet so, we have to match on
// if we have it or not to make a decision to give blood, we don't want to give the wrong blood.

// Lesson 3.4 Result Types
// Result types are also built in discriminated unions. They can be much better than exception handling in the right
// situation. For instance, just because a map doesn't have a value we key we wouldn't want to throw an exception.
let patientsWithKey = [ (1234, "Ted"); (2345, "John") ] |> Map
// I'm using Guid here as a unique key for every patient that gets added to our system. Notice that it is the .NET
// library style of Module + method, not Module + function.
// Now what happens if we try to get a patient with a key that doesn't exist?
patientsWithKey[1]
// I got an exception when I tried to get a key outside the bounds of the map!
// What could I do instead?
// One option is to use the built in method, try get value which will return true with a value or false.
let result = patientsWithKey.TryGetValue 1
// This is fine because we can pass a bool up to check, but a more explicit way to do this would be to send an error
// back up for us to check against.
let result =
    match patientsWithKey.TryGetValue(1) with
    | true, patient -> Result.Ok patient
    | false, _ -> Result.Error "Patient with ID 1 isn't in the hospital."

let patientInHospital =
    match result with
    | Ok patient -> printfn $"{patient} is in the hospital."
    | Error error -> printfn $"{error}"
// Now we are getting much more specific information about if the patient is in the hospital or not.
// Review
// Let's create a hospital for our patients to stay in.
type Hospital = { Name: string; Patients: Patient seq }

// This is a bad hospital because they always have problems remembering if they have a patient or not, let's help them
// by moving from their paper system to a new electronic one.
let badHospital =
    { Name = "Bad Hospital"
      Patients = patients }

// One problem we have, if badHospital is immutable, how do we do things like update our patient list?
// We have no problem reassigning the patient list every time we get new ones or some check out, but we
// don't have a way to change bad hospital without mutating it, which we don't want to do.
// badHospital.Patients <- Seq.empty This won't work!
// Luckily, there's a built in way to update a record in F#.
let badHospitalUpdate = {badHospital with Patients = Seq.removeAt 0 patients }
// We removed Ted so now the hospital is empty!
// We are doing this update manually via the code here, but imagine a long running process where we are
// passing the updated hospital instead. In that case, it would just be a function that takes the old
// hospital and returns a new one.

// Lesson 3.5 More Collections?

// Lesson 3.6 Maps and Sets



