# CheckStandarts
## Popis
- Jedná se o plug-in do [Autodesk Revitu 2023](https://www.autodesk.cz/products/revit/), který ověří geometrii, zda odpovídá normám, vyhláškám, doporučením.

## Podrobný popis, co zatím umí ověřit
### Schodiště
- Délku kroku dle Lehmanova vzorce
- Výšku schodu
- Hloubku/šířku schodu
- Sklon schodiště
  
### Rameno schodiště
- Počet schodů v rameni
- Šířku schodišťového ramene

## Požadavky k chodu
- Window 10 64 bit
- .NET Framework 4.8
- Autodesk Revit 2023

## Autorská práva
- Zdarma, volně šiřitelné
- Odkaz na podrobné [znění](https://github.com/HynPl/CheckStandarts/blob/main/LICENSE.md)

## Naprogramováno v
- Visual Studio 2022
### Reference
- .NET Framework 4.8
- Autodesk Revit 2023 - Reference RevitAPI.dll + RevitAPIUI.dll
- Nuget [CarlosAgExcelXmlWriterLibrary](http://www.carlosag.net/tools/excelxmlwriter/) k exporu do Excelu
