
# TodoConsoleApp
Rozwiązanie warsztatów nr 1 w CodersLab.
## Obsługiwane funkcje programu
* Dodawanie nowych zadań,
* Usuwanie wybranych zadań,
* Zapis listy zadań do pliku,
* Wczytywanie listy zadań z pliku.


### Dodawanie nowych zadań
Aplikacja pozwala na dodawanie nowych zadań na 3 różne sposoby.
- #1 - wywolanie polecenia 'add' w oknie programu.
```sh
Wprowadź polecenie: add
Wprowadź nowe zadanie według podanego schematu:
        Zdarzenie całodniowe:                  opis;data_rozpoczęcia;ważne[opcjonalnie]
        Zdarzenie o określonym czasie trwania: opis;data_rozpoczęcia;data_zakończenia;ważne[opcjonalnie]
Wprowadź nowe zadanie: Nowe zadanie;2018-10-30;2018-11-02;true
```
> Wywołanie tego polecenia spowoduje pojawienie się dokładnych instrukcji dotyczących wprowadzania nowego zadania.
- #2 - wprowadzenie nowego zadania bezpośrednio z pola poleceń.
```sh
Wprowadź polecenie: add Nowe zadanie wprowadzone bezpośrednio po poleceniu 'add';2018-10-30;false
```
> Wywołanie tego polecenia spowoduje dodanie nowego zadania bez wyświetlania dodatkowych informacji.
- #3 - wprowadzenie nowego zadania jako parametr programu.
```sh
>TodoConsoleApp.exe add Zadanie dodane jako parametr;2018-10-30;true
```
> Wywołanie tego polecenia spowoduje dodanie nowego zadania do wczesniej zapisanej listy zadań.

### Wyświetlanie wprowadzonych zadań
```sh
Wprowadź polecenie: show
```
> Wywołanie polecenia "show" spowoduje wyświetlenie wszystkich dodanych zadań.
```sh
|Index|Opis                                                    |Data rozpoczęcia|Data zakończenia|Całodniowe|Ważne|
|0    |Nowe zadanie                                            |2018-10-30      |2018-11-02      |False     |True |
|1    |Nowe zadanie wprowadzone bezpośrednio po poleceniu 'add'|2018-10-30      |                |True      |     |
```

### Usuwanie wybranego zadania
Istnieją dwie metody usunięcia zadeklarowanych zadań:
- #1 - Wywołanie polecenia 'remove'
```sh
Wprowadź polecenie: remove
Podaj numer id zadania które chcesz usunąć [0-1]:
```
- #2 - Wprowadzenie polecenia 'remove' wraz z numerem id wybranego zadania
```sh
Wprowadź polecenie: remove 0
```
### Sortowanie listy zadań
Aby posortować listę zadań należy użyć polecenia 'sort' a następnie wybrać jedną z dostępnych opcji.
```sh
Wprowadź polecenie: sort
Wybierz kolumnę do posortowania:
        Opis                   [0]
        Data rozpoczęcia       [1]
        Data zakończnia        [2]
Wprowadź numer kolumny do posortowania:
```
### Zapis utworzonej listy zadań do pliku
Aby zapisać utworzoną listę zadań należy wywołać polecenie 'save'
```sh
Wprowadź polecenie: save
```
> Utworzona lista zadań zostanie zapisana w pliku 'data.csv'.
### Generowanie pliku html z listą zadań
Aby wygenerować plik html z listą wszystkich utworzonych zadań należy wybrać polecenie 'savehtml'
```sh
Wprowadź polecenie: savehtml
```
>Wygenerowany plik będzie wyglądał w następujący sposób: 
### Wczytywanie listy zadań z pliku
Aby wczytać listę zadań z pliku należy wywołać polecenie 'load'.
```sh
Wprowadź polecenie: load
```
> Jeżeli istnieje plik 'data.csv' program wczyta wszystkie zadania w nim zapisane.