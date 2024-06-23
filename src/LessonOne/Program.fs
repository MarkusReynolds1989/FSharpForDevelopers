// Lesson 1.5

// How to bind a value to a variable.
let x = 3

// How to print to the console
printfn $"{x}"

// An integer is a non-decimal number such as 1, 100_000, 1_000_000, -5000 and so on.
let intNumber = 1_000_000

// A float is a number that is a decimal, such as 0.1111111, -200.4000, 100.000001 and so on. There are also
// doubles and decimals in .net, but we will cover those later.
let floatNumber = -200.111104

// A character is a single quoted letter/numbers/etc.
let character = 'a'

// A string is a double-quoted collection of characters "I love f#"
let fire = "🔥 I love F# ❤️‍🔥"
// Note that you can put any token you want into the string. Let's go ahead and print it:
// Note your console may not support the emoji characters.
printfn $"{fire}"

// These are what we would consider basic data types, however now we will cover some more sophisticated ones.
// First off, we can cover a 'list'. A list is a singley-linked list
// that is each node in the link points to the next item.
let groceryList = [ "banana"; "flour"; "eggs"; "milk" ]

// A tuple is also a collection of items, however, it can take items of different types.
// Note that the tuple has a signature of the exact types in the tuple it's made up of
// as opposed to above, where we only have a signature of "string list" which means that list can only have strings.
let groceryListWithPrices =
    ("banana", 1.00, "flour", 2.00, "eggs", 6.00, "milk", 5.00)
// This tuple has a lot of drawbacks that you will see soon. The first problem is we can't iterate through it.

// Making a tuple like above can be clunky as we will see later, we usually want to use a more robust and useful
// data type, a record.
type Grocery = { Item: string; Price: float }

// Now instead of having to make a tuple, we can make a list of grocery items we need.
let betterGroceryList =
    [ { Item = "banana"; Price = 1.00 }
      { Item = "flour"; Price = 2.00 }
      { Item = "eggs"; Price = 6.00 }
      { Item = "milk"; Price = 5.00 } ]

// Now it will be more obvious when we want to print this list. We can do this very simply by iterating through
// the list of items with a for loop.
for item in betterGroceryList do
    printfn $"{item}"

// Keep in mind that F# is whitespace sensitive and requires the use of tab to indent the next line
// this is different from languages like C#, where whitespace is ignored.
