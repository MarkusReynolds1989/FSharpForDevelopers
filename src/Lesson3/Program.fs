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
type Patient = {
    FirstName: string
    LastName: string
    Age: int
    // In kilograms.
    Weight: double
    // In meters.
    Height: double
}
// Now we have the shape of the data needed to create a patient, let's go ahead and create one.
let ted = {
    FirstName = "Ted"
    LastName = "Tedson"
    Age = 45
    Weight = 100.0
    Height = 1.8
}
// Now we have a patient, imagine if we had to individually track each individual part of that, it would have been
// really annoying and time-consuming to remember each variable that associated to Ted.
// I can pack up many patients into a collection without any issues.
let patients = seq [ted]
// Now we have a seq of patients instead of individual patients. Remember that F# is strongly typed, we didn't tell
// it what the type of the seq should be but, it was able to discern it itself.
// Exercise 3.1
// Create another patient and load it into the patients sequence by using Seq.append.

// Lesson 3.2 Discriminated Unions
// We've talked about records which are a powerful user defined type, but there is also another very
// powerful user defined type that can help us in other ways. Supposed that we need to use a bool (true or false) value
// for something. Many would agree that true and false are not very descriptive for things like flags, so what
// are our options? We can use a discriminated union.
type BloodType = A | B | O
// I want my patients to have a blood type associated with them, so I can add in a discriminated union of the options.
// Suppose Ted has a blood type of A, what we can do now is set up a match against the DU of his blood type to
// take different actions depending on his blood type.
let tedsBloodType = A
// Again, I didn't have to tell it the type, it was able to infer.
// You can be explicit though.
let johnsBloodType: BloodType = B

match tedsBloodType with
| A -> printfn "Starting A blood type transfusion."
| B | O -> printfn "Shutting down, critical error, wrong blood type."
// Notice that B and O do the same thing when they are matched, that is safer than adding a _ wildcard to handle anything else.

// Lesson 3.3 Option Types

// Lesson 3.4 Result Types

// Lesson 3.5 More Collections?

// Lesson 3.6 Maps and Sets