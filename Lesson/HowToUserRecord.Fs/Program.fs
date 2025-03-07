// For more information see https://aka.ms/fsharp-console-apps
type Circle = {Radius: double}

type Page = { PageIndex: int
              Content: string
             }

type Book = {
    Author: string
    Title: string
    Price: int
    Pages: Page list
}


let authors =  (List.init 6 (fun _ -> "Scixing"))
               @ (List.init 6 (fun _ -> "Moob"))
               @ (List.init 6 (fun _ -> "BoredYear"))
let books = authors
            |> List.map (fun c -> {Author = c; Title = "Book"; Pages = []; Price  = 10 })


            
module Tools =
    let scale (factor: double) (circle: Circle) =
        {circle with Radius =  circle.Radius * factor}
    
    let addTailPage (book: Book) =
        { book with
            Pages = { PageIndex = book.Pages.Length + 1; Content = "test" } :: book.Pages }
    let slice start count (book: Book) =
        {book with Pages = book.Pages |> List.skip start |> List.take count }
        
    let addBookTitle symbol (book: Book) =
        {book with Title = symbol + book.Title + symbol}
        
open Tools
books |> List.map Tools.addTailPage
      |> List.iter (printfn "%A")


books |> List.map Tools.addTailPage
      |> List.iter (printfn "%A")
      
books |> List.filter
             (fun s ->
                match s with
                    | { Author = ("Scixing" | "BoredYear")
                        Pages = pages} when List.length pages > 12  -> true
                    | _ -> false )
      |> List.iter (printfn "%A")