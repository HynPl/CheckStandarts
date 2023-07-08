# CheckStandarts
## Popis
- Jedná se o plug-in do [Autodesk Revitu 2023](https://www.autodesk.cz/products/revit/), který ověří geometrii projektu, zda odpovídá normám, vyhláškám, doporučením.

## Stažení a instalace
- Plug-in v tuto dobu není kompletní

## Podrobný popis, co zatím umí ověřit
### Schodiště
- Délku kroku dle Lehmanova vzorce
- Výšku schodu
- Šířka stupně
- Sklon schodiště
  
### Rameno schodiště
- Počet schodů v rameni
- Šířku schodišťového ramene

## Požadavky k chodu
- Window 10 64 bit
- .NET Framework 4.8
- Autodesk Revit 2023

## V případě oběvení chyby
- Prosím podívejte se zda již neexistuje existující [problematika](https://github.com/HynPl/CheckStandarts/issues), případě že není, založte [nové](https://github.com/HynPl/CheckStandarts/issues/new)

## Autorská práva
- Zdarma, volně šiřitelné
- Odkaz na podrobné [znění](https://github.com/HynPl/CheckStandarts/blob/main/LICENSE.md)

## Naprogramováno v
- Visual Studio 2022
### Reference
- .NET Framework 4.8
- Autodesk Revit 2023 - Reference RevitAPI.dll + RevitAPIUI.dll
- Nuget [CarlosAgExcelXmlWriterLibrary](http://www.carlosag.net/tools/excelxmlwriter/) k exporu do Excelu