open System.Collections.Generic

// Lesson 2.1 Immutability
// When you use let to bind a variable it is immutable.
let y = 3

// In other languages you could mutate it, you could assign a new value to y, in F# that will be an error.
// But suppose you want to mutate y? Then you should declare it as mutable.
let mutable x = 3
// This variable can be mutated and assigned a new value now.
x <- 4
// This way of programming is error-prone and can lead to a lot of problems in situations where
// x is being mutated without us knowing. It's better if we can always know that our variables won't be changed.
// The question then, is how do we do anything useful if we are worried about side effects?
// We will cover that in depth later, but first let's understand the concept of pure functions.

// Note, that you can shadow variables which means you can reassign them. I don't recommend this because it can cause
// confusion on what the state of the variable is.
// let y = 344

// In .NET this is called a doc tag. This enables IDEs to link robust documentation about functions and methods to
// the functions so when they are called you can get more information about them. Just hover over the function name
// and see the description.
/// <summary>
/// A pure function is a function that given the same inputs it always returns the same outputs. It is
/// free from side effects which means it will do exactly what it says without making changes to anything.
/// </summary>
/// <param name="inputOne"></param>
/// <param name="inputTwo"></param>
let pureFunction inputOne inputTwo = inputOne + inputTwo

// Functions like these allow us to optimize our code and write it in cleaner ways than if we were to use mutation
// and side effects. For instance, if you always knew that certain inputs would generate certain outputs you
// could generate a table everytime the function was hit and then do a lookup instead of a calculation. This concept
// is called memoization.
// It's also easier to test and debug these functions as they do one thing without altering anything else.

// Exercise 2.1
// Before moving on to the next sub-lesson create a function that takes the height and width of a rectangle
// and returns its area.
// Remember you can experiment in F# Interactive to get instant feedback.
// Here's a starter signature:
// let area height width = ??

// Lesson 2.2 Higher-Order Functions
// Let's explore higher-order functions. We went over them a little bit in 1.6, but now we can explore what they are
// about and what superpowers they unlock.

// We talked before about a function that can take another function as an argument.
let slottedFunction f argument = f argument

// Observe the two functions below, we are passing a different function into each slottedFunction.
// Observe also the syntax for what we call "anonymous functions" these are functions that we can
// declare inline and don't need to be named. The let name binding above is a syntactic shortcut for this.
let result = (fun x -> x + 3) 3
let resultTwo = (fun y -> y + 3.0) 3.4
// Last observation, observe that we can use different types and different type functions to pass into slottedFunction.
// F# is a strongly typed language, this is a powerful tool called generics we will talk more about later.
// Remember that we can also return a function we create from another function.
let createdFunction argument = fun () -> argument

// Now that we understand a higher order function and passing functions, let's talk about some higher order functions
// that are built into F#. We always want to reach for the tools that are built in instead of making our own if
// we can help it.
// Let's look at a few of the most common ones.
let groceries = [ "bananas"; "milk"; "chips"; "eggs" ]

// Suppose we want to make all of these capital and return a new list with those changes.
// In an imperative and mutable context we might just loop through each element of the list and alter them.
// But in F# and in functional programming, we are going to use a built-in function called 'map' that will
// create a new list instead.

// This will take every string in the list and make them all capitalized. However, notice the .ToUpper()
// syntax we used. This is called a "method call". This is different from a function because this functionality
// is attached to the variable itself.
let upperCaseGroceries =
    List.map (fun (grocery: string) -> grocery.ToUpper()) groceries

// Map is a function that is included in the List module. Map is available for most collections and takes every item
// and does some function on them and then collects the result. We are "mapping" an item to another item.

// Next we will take a look at another very useful function, Filter.
let justMilk = List.filter (fun grocery -> grocery = "milk") groceries

// Filter will go through and use a predicate on each item in the list and then if the predicate returns true the item
// will go into a new list. The false items will be ignored and not brought into the new list.

// Lastly, let's run a fold on the list. A fold runs a function against each item in the list
// and accumulates the result as the return value.

let groceryCount = List.fold (fun acc _grocery -> acc + 1) 0 groceries

// In this case we don't use the grocery itself in our calculation, so we just put an underscore at the start
// to show we don't care about it. We could also have just put an underscore.

// Exercise 2.2
// Now try it yourself, create a list of your favorite foods and then count how many start with the letter p.
// Hint: Because you are being asked for a count you should use a fold.

// Lesson 2.3 Pattern Matching
// Next we will talk in-depth about pattern matching. We went over it a little bit before, but now we will do a full
// investigation of what it is and what it enables us to do.

// A simple pattern match:
match 3 = 0 with
| true -> printfn "How is this possible?"
| false -> printfn "As expected."

// The components of a match are the match keyword, the expression or variable to match on, and then the with keyword.
// The | bars will be evaluated from top to bottom. For instance, we will check if
// 3 = 0 is true first before we check if it is false.
// Alternatively, you can use the "function" keyword:
3 = 0
|> function
    | true -> printfn "How is this possible"
    | false -> printfn "As Expected."

// There is also the concept of a "guard".
// We use the "when" keyword to enhance our match even more and be more specific.
let x = 3

match x = 0 with
| true when x > 2 -> printfn "3 is greater than 2, but it's not equal to 0."
| false when x < 1 -> printfn "3 is not equal to 0, so that part is true, however it is not less than 1."
| false when x > 1 -> printfn "This will work! x is greater than 1 and it is not equal to 0."
| true -> printfn "This won't get touched, but it's best practice to always cover every possible outcome of a match."
| false -> printfn "This won't get touched, but it's best practice to always cover every possible outcome of a match."

// We can also match on collections, such as a list of groceries!
match groceries with
| [ "milk" ] -> printfn "There's only milk in the list, that's not right."
| [] -> printfn "The grocery list is empty!"
| [ "bananas"; "milk"; "chips"; "eggs" ] -> printfn "This is the right list."
// Notice the underscore to mean "anything else" this is a catchall in case it doesn't match anything else.
// This is an antipattern and should be avoided as much as possible. We should always be explicit with every
// possible option.
| _ -> printfn "For any other instance, won't be matched."

// Matches are perfect for use in tandem with Discriminated Unions which we will get to in the next lesson, we
// will cover matching on Discriminated Unions when we get to it.

// Exercise 2.3
// Try matches for yourself, try to see if you can print if the groceries list has a certain amount of groceries in it.

// Lesson 2.4: Lists and Collections
// There are a multitude of collections available in F# and they are all good for different things.
// A list, or a linked-list, is good for situations where we need to go through every item in a collection
// and do some sort of work with it.
let groceryList = [ "banana"; "eggs" ]
// A list can have any amount of data in it. The way a list works is that one node in the list is pointing to the next
// item in the list. This is great for when we need to run linear algorithms, in that we will touch every element.
// This is not great when we need to get a specific element because that will be a linear lookup, which is not
// as efficient as some other collections. Lists are also immutable, you cannot change the elements of the list in
// any way once it is set. You can only create a new list from the old one.
let newList = List.updateAt 0 "milk" groceryList
// Notice that we couldn't change the original list, we had to update the old list by creating a new one.

// Another collection type we have to work with in F# is Arrays. Arrays work very similarly to how they work in other
// languages. Looking up an item in the array by index is a constant time operation, unlike the linear lookup in
// lists.
let animals = [|"dog"; "cat"; "monkey"; "horse"|]
// We can update any element we want of the array, but we can't grow or shrink the array, just like the list.
animals[0] <- "mule"
// Notice before how I was able to find a function to run on a collection. The collections usually have several
// utility functions under their module. Before, I used List.updateAt, but there are also many Array functions as well.
Array.length animals |> printfn "%d"
let moreAnimals = Array.append animals [|"dog"; "frog"; "butterfly"|]
// We can expand the array by taking the old array and adding a new array to it, then that addition
// can be assigned to a new array. Keep in mind that these operations are linear space complexity.
// There's also the Map collection, which is similar to a HashMap or collection of key value pairs.
let groceryPrices = [("banana", 1.0); ("eggs", 4.00); ("milk", 5.00)] |> Map
// Get the price of bananas.
groceryPrices["banana"] |> ignore
// We can't mutate a map either, if we want to do changes we have to create a new map.
// Finally, we have the Seq collection. The Seq collection is a lazy collection that is used ot iterate over items
// lazily. It is very similar to a stream.
let sequence = seq [1;2;3;4]
// In a normal program, this operation wouldn't start until the last possible moment when it's needed.
// In other words, the sequence wouldn't be enumerated until forced to do so.
let result = sequence |> Seq.map(fun x -> x + 1)
// You can also use infinite sequences.
let infiniteSequence = Seq.initInfinite id

// What do we want to do in cases where we want to mutate collections?
// We have the .NET libraries available for this! I will show two examples here for now and then
// later we will go over more.
// Remember Map from before is immutable, we can use .NET dictionaries as well that are fully mutable.
let x = Dictionary<string, int>()
// Mutating the collection is no problem, add, remove, etc.
x.Add("banana", 1)
x.Remove("banana") |> ignore

// Resize array is a fully mutable version of the array from before. 
let y = ResizeArray<int>()


