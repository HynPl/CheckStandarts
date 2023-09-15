# CheckStandarts
[![en](https://img.shields.io/badge/lang-en-red.svg)](README-EN.md)
## Popis
- Jedná se o plug-in do [Autodesk Revitu 2023](https://www.autodesk.cz/products/revit/), který ověří geometrii projektu, zda odpovídá normám, vyhláškám, doporučením v České republice.

## Stažení a instalace
- Vyextrahovat [ZIP soubor](https://github.com/HynPl/CheckStandarts/tree/main/releases/v0.1) do složky C:\ProgramData\Autodesk\Revit\Addins\2023\

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
- Podpůrné součásti: PicoXLSX (Uložení souboru Excelu), Raphael Stoeckli, MIT Licence

## Naprogramováno v
- Visual Studio 2022
### Reference
- .NET Framework 4.8
- Autodesk Revit 2023 - Reference RevitAPI.dll + RevitAPIUI.dll
