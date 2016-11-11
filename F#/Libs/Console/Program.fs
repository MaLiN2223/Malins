open System
open System.Diagnostics
let sign num = 
    if num>0 then "positive"
    elif num < 0 then "negative"
    else "zero"

let rec silnia num = 
    if num <= 1 then 1
    else num * silnia (num-1)
      
let silnia3 x =
    let rec tail x f =
        if x<=1 then 
            f()
        else
            tail(x-1)(fun()->x*f())
    tail x (fun()->1)

let rec silnia2 n =
    match n with
    |0 | 1 ->1
    | _ -> n * silnia2(n-1) 

let main()=
    let n = 30
    let values:list<int> = [1..1..17]
    let values2:list<int> =[1..1000000]
    let mutable result = int(0)
    let mutable k:int = 0
    let mutable i:int =0
    let timer:Stopwatch = new Stopwatch() 
    timer.Restart()
    for k in values2 do
        for i in values do
            result <- silnia3(i) 
    timer.Stop()
    printf "%s\n" (timer.Elapsed.ToString()) 
    timer.Restart() 
    for k in values2 do
        for i in values do
            result <- silnia3(i) 
    timer.Stop()
    printf "%s\n" (timer.Elapsed.ToString()) 
    for k in values2 do
        for i in values do
            result <- silnia3(i) 
    timer.Stop()
    printf "%s\n" (timer.Elapsed.ToString()) 
    timer.Restart()    
    Console.ReadKey()

main()
