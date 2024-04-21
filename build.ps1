$ROOT=pwd

cd src

"Building..."
dotnet build /tl
"`n`n`n=============================================="

"Testing..."
dotnet test /tl

cd $ROOT
