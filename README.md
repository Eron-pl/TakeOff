# TakeOff `v1.0.0`
_Patryk Sablik_  
_Mateusz Nawieśniak_  
_Bartłomiej Pisczur_

## 1 Wstęp
### 1.1 Cel dokumentu
Dokument ten ma za zadanie przybliżyć funkcje, potencjalnych klientów oraz przypadki użycia
programu **TakeOff**. W pierwszej części dokumentu zostaną przybliżone założenia dotyczące
ogólnych zasad działania, funkcji, docelowych grup użytkowników oraz ograniczeń programu.
Kolejna część przeznaczona będzie na przykładowe przypadki użycia (use cases) ukazujące
scenariusze działania programu w praktyce.

### 1.2 Struktura przypadków użycia oraz wyjaśnienie pojęć
Każdy przypadek użycia będzie się składał z następujących części:
* UC #(numer) – numer identyfikacyjny przypadku
* Aktorzy – użytkownicy uczestniczący w scenariuszu
* Cele – oczekiwany efekt po wykonaniu scenariusza
* Warunki początkowe – Stan od którego zaczyna się scenariusz
* Scenariusz bazowy – Wypunktowana sieć działań scenariusza głównego
* Scenariusz alternatywny – Wypunktowana sieć działań scenariusza alternatywnego
* Warunki końcowe – Stan na którym kończy się scenariusz, powinien być zgodny z celami

### 1.3 Definicje pojęć w diagramie
Definicje pojęć zawartych w diagramie:
* Użytkownik - osobą korzystająca z programu
* System - system operacyjny, w którym działa program
* Aplikacja - program posiadany przez użytkownika lub taki, który użytkownik
chce zainstalować na swoim systemie
* Repozytorium danych - baza danych zawierająca informacje na temat programów
* Zasoby producentów - źródła pobieranych aplikacji oraz informacji na ich temat

## 2 Opis ogólny 
### 2.1 Opis systemu
System ma za zadanie przyspieszyć proces przywracania systemu do stanu używalności po
sformatowaniu go. Do głównych założeń należy responsywność, oraz prostota użytkowania w takim
stopniu, aby program był w stanie zrobić jak najwięcej bez ingerencji użytkownika. W zależności od
preferencji użytkownika, będzie istnieć możliwość ręcznego wyboru aplikacji do pobrania i
zainstalowania, predefiniowane pakiety programów skierowane do poszczególnych grup odbiorców,
lub możliwość zapisania przed formatowaniem do pliku posiadanych programów, aby potem po
sformatowaniu urządzenia można było za pomocą tego pliku automatycznie pobrać wszystkie
poprzednio zainstalowane programy (lub przed pobieraniem ręcznie wykluczyć ich część).
Sama nazwa odnosi się do założonego przeznaczenia programu - użytkownik
włącza nowy (lub po sformatowaniu) sprzęt i chce szybko zainstalować wszystkie
programy jakich potrzebuje. Cały proces ma byc szybki jak odlot samolotu.

### 2.2 Użyte Technologie
System stworzony zostanie w środowisku **.NET Core**, w języku **C#** i jego miejscem docelowym będą komputery
stacjonarne i przenośne. Do zapisu oraz odczytu danych będzie wykorzystywany format pliku **JSON**

### 2.3 Zarys interfejsu
Planowany interfejs ma być łatwy oraz intuicyjny dla użytkownika, ma ułatwić mu
szybkie korzystanie z programu. W tym samym czasie szata graficzna ma się wizualnie podobać użytkownikowi.

![Architektura programu](https://i.ibb.co/j8GFnNv/szkic-interfesju.png)

Główne funkcje będą znajdować się w pasku po lewej stronie, aby użytkownik miał
zawsze łatwy i szybki dostęp do nich. Na środku będzie treść programu, w każdej
zakładce treść będzie się różnić.

## 3 Architektura programu
Program współpracuje z systemem - instaluje na niego aplikacje, ich aktualizacje
oraz dokonuje na nim skanów w celu uzyskania informacji na temat posiadanych
przez użytkownika aplikacji. Za pośrednictwem internetu będzie sprawdzał oraz
pobierał zasoby producentów. Informacje o wersjach aplikacji będą zapisywane w
naszym repozytorium danych.

## 4 Wymagania
### 4.1 Funkcjonalne
* Przeszukiwanie urządzenia pod kątem zainstalowanych programów oraz zapisywanie tej
informacji do pliku
* Odczytywanie informacji o poprzednio zainstalowanych programach z pliku oraz dodawanie ich
do kolejki instalacji
* Wybór programów do zainstalowania z listy
* Wybór pakietu programów do zainstalowania z listy
* Pobieranie oraz instalacja programów w tle

### 4.2 Niefunkcjonalne
* Przejrzystość interfejsu bez zbędnych ukrytych funkcji
* Możliwość skorzystania z domyślnej funkcjonalności za pomocą 2-3 kliknięć
* Proces od zapisania do pliku do rozpoczęcia instalacji nie powinien przekraczać 5 minut
* Program powinien pytać o prawa administratora tylko raz – przed instalacją wszystkich
programów


## 5 Przypadki użycia
### 5.1 UC #001: Instalacja programów z listy
__Aktorzy:__  
Użytkownik  

__Cele:__  
Instalacja programów wybranych przez użytkownika

__Warunki początkowe:__  
System użytkownika jest zaraz po formatowaniu, nie ma na nim zainstalowanych żadnych
programów z listy

__Scenariusz bazowy:__
1. Użytkownik wybiera opcję instalowania programów z listy
2. System wyświetla formularz zawierający listę wspieranych programów razem z checkboxami
3. Użytkownik zaznacza checkboxy programów, które chciałby zainstalować
4. Użytkownik potwierdza wybór
5. System sprawdza, czy żaden z wybranych programów nie jest już zainstalowany
6. System rozpoczyna pobieranie plików instalacyjnych
7. System instaluje pobrane programy

__Scenariusz alternatywny:__
* Użytkownik zatwierdził wybór bez wybrania programu  
Wyświetla się komunikat o braku wyboru  

__Warunki końcowe__:  
Na urządzeniu zainstalowane zostały wcześniej wybrane programy  

### 5.2 UC #002: Instalacja programów z pakietu
__Aktorzy:__  
Użytkownik  

__Cele:__  
Instalacja programów z pakietu wybranego przez użytkownika

__Warunki początkowe:__  
System użytkownika jest zaraz po formatowaniu, nie ma na nim zainstalowanych żadnych
programów z pakietu
Scenariusz bazowy:
1. Użytkownik wybiera opcję instalowania pakietu oprogramowania
2. System wyświetla listę dostępnych pakietów oprogramowania
3. Użytkownik wybiera odpowiedni pakiet oprogramowania
4. Pojawia się okno dialogowe z potwierdzeniem wyboru
5. Użytkownik potwierdza wybór
6. System sprawdza czy żaden z programów będących w pakiecie nie jest już zainstalowany
7. System rozpoczyna pobieranie plików instalacyjnych
8. System instaluje pobrane programy

__Scenariusz alternatywny__:    
_Brak_

__Warunki końcowe:__  
Na urządzeniu zainstalowane zostały wcześniej wybrane programy  

### 5.3 UC #003: Zapisywanie zainstalowanych programów do pliku
__Aktorzy:__  
Użytkownik

__Cele:__  
Utworzenie pliku zawierającego informację o zainstalowanych na urządzeniu programach

__Warunki początkowe:__  
System użytkownika nie został jeszcze sformatowany, użytkownik przygotowuje się do
formatowania

__Scenariusz bazowy:__
1. Użytkownik uruchamia program sprawdzający oprogramowanie
2. Program pyta użytkownika o lokalizacje zapisu pliku z programami
3. Użytkownik wybiera lokalizację zapisu
4. Program wyszukuje na urządzeniu wspierane programy
5. Program zapisuje dane do pliku we wcześniej wskazanej lokalizacji

__Scenariusz alternatywny__:  
* Zainstalowane programy nie są wspierane przez System 
 
__Warunki końcowe:__  
Został stworzony plik zawierający spis zainstalowanych na urządzeniu wspieranych programów  

### 5.4 UC #004: Odczytywanie i instalacja programów z wcześniej przygotowanego pliku
__Aktorzy:__   
Użytkownik

__Cele:__   
Instalacja programów zapisanych we wcześniej przygotowanym pliku

__Warunki początkowe:__   
System użytkownika jest zaraz po formatowaniu, nie ma na nim zainstalowanych żadnych
programów z pliku

__Scenariusz bazowy:__
1. Użytkownik wybiera opcję instalowania programów z pliku
2. System wyświetla eksplorator plików
3. Użytkownik wybiera w eksploratorze wcześniej wygenerowany plik
4. System znajduje dane programów zapisanych w pliku
5. System wyświetla listę znalezionych programów razem checkboxami
6. Użytkownik odznacza niepotrzebne programy z listy
7. Użytkownik zatwierdza wybór
8. System sprawdza czy żaden z wybranych programów nie jest już zainstalowany
9. System rozpoczyna pobieranie plików instalacyjnych
10. System instaluje pobrane programy

__Scenariusz alternatywny:__
* Użytkownik nie odznaczył żadnych programów
System instaluje wszystkie programy z listy
* Odczytywany plik jest pusty
Program wyświetla komunikat z informacją że plik jest pusty
* Użytkownik wskazał niekompatybilny z systemem plik
System wyświetla komunikat o niepoprawnym pliku

__Warunki końcowe:__    
Na urządzeniu zainstalowane zostały programy z pliku  

### 5.5 UC #005: Sprawdzanie wersji zainstalowanego oprogramowania
__Aktorzy:__     
Użytkownik

__Cele:__   
Sprawdzanie wersji zainstalowanego oprogramowania

__Warunki początkowe:__  
System użytkownika jest już po instalacji wspieranych programów

__Scenariusz bazowy:__
1. System w regularnych odstępach czasowych przeprowadza audyt wersji zainstalowanych
programów
2. System porównuje zgromadzone dane z bazą danych zawierającą aktualne wersje
oprogramowania
3. System powiadamia użytkownika o dostępności aktualizacji

__Scenariusz alternatywny:__
* System nie znalazł aktualizacji

__Warunki końcowe:__  
Sprawdzona została aktualność oprogramowania na urządzeniu  

### 5.6 UC #006: Aktualizacja zainstalowanego oprogramowania
__Aktorzy:__  
Użytkownik

__Cele:__  
Aktualizacja zainstalowanego oprogramowania

__Warunki początkowe:__  
System znalazł aktualizacje zainstalowanego oprogramowania i oczekuje na potwierdzenie
aktualizacji przez użytkownika

__Scenariusz bazowy:__
1. Użytkownik za pomocą powiadomienia uruchamia interfejs aktualizacji
2. System wyświetla listę programów wymagających aktualizacji
3. Użytkownik uruchamia proces aktualizacji
4. System pobiera nowe wersje plików instalacyjnych oprogramowania
5. System aktualizuje oprogramowanie

__Scenariusz alternatywny:__
* Użytkownik nie uruchomił aktualizacji  


__Warunki końcowe:__    
Oprogramowanie zostało zaktualizowane

### 5.7 UC #007: Wyszukiwanie programów do instalacji
__Aktorzy:__  
Użytkownik

__Cele:__  
Wyszukanie konkretnych programów

__Warunki początkowe:__  
Program wyświetlił listę wszystkich programów

__Scenariusz bazowy:__
1. Użytkownik wchodzi w zakładkę 'Pobieranie'
2. Użytkownik wpisuje frazę w pasek wyszukiwania
3. Program wyświetla programy zgadzające się z podaną frazą

__Warunki końcowe:__    
Programy zostały wyświetlone zgodnie z kryteriami



