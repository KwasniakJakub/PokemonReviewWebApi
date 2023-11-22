# Projekt Interfejsu API ASP.NET Core 

Witaj w repozytorium zawierającym kod źródłowy mojego projektu interfejsu API napisanego w ASP.NET Core. Ten projekt został stworzony, ucząc się z kursu  na Youtube "ASP.NET Web API Tutorial 2022" Autorstwa "Teddy Smith"

## Opis

Projekt ten jest implementacją interfejsu API w technologii ASP.NET Core. Jest to aplikacja internetowa, która umożliwia pobieranie pokemonów, pobieranie pokemona po określonym id, usuwanie, dodawanie oraz edytowanie pokemona po określonym id.

## Funkcje

-Pobieranie Wszystkich Pokemonów:

Endpoint: GET /api/pokemon
Metoda: GetPokemons
Zwraca listę wszystkich Pokemonów w formie listy obiektów PokemonDto.

-Pobieranie Konkretnego Pokemona:

Endpoint: GET /api/pokemon/{pokemonId}
Metoda: GetPokemon(int pokemonId)
Pobiera informacje o konkretnym Pokemonie na podstawie pokemonId.

-Pobieranie Oceny Pokemona:

Endpoint: GET /api/pokemon/{pokemonId}/rating
Metoda: GetPokemonRating(int pokemonId)
Pobiera ocenę danego Pokemona na podstawie pokemonId.

-Dodawanie Nowego Pokemona:

Endpoint: POST /api/pokemon
Metoda: CreatePokemon
Tworzy nowego Pokemona na podstawie przesłanych danych, właściciela (ownerId), kategorii (categoryId) i informacji o Pokemonie (PokemonDto).

-Aktualizowanie Informacji o Pokemonie:

Endpoint: PUT /api/pokemon/{pokemonId}
Metoda: UpdatePokemon
Aktualizuje dane o konkretnym Pokemonie na podstawie przesłanych danych, właściciela (ownerId), kategorii (categoryId) i zaktualizowanych informacji o Pokemonie (PokemonDto).

-Usuwanie Pokemona:

Endpoint: DELETE /api/pokemon/{pokemonId}
Metoda: DeletePokemon
Usuwa Pokemona na podstawie jego pokemonId, usuwa również związane z nim recenzje.

## Wymagania systemowe

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- Dowolne środowisko programistyczne obsługujące ASP.NET Core (np. Visual Studio, Visual Studio Code)

## Uruchamianie

1. Sklonuj repozytorium: `https://github.com/KwasniakJakub/PokemonReviewWebApi.git`
2. Otwórz projekt w wybranym środowisku programistycznym.
3. W pliku appsettings.json określ połączenie z bazą danych (np. lokalną)
   {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDatabase;Integrated Security=True;"
  }
  // ...
}
5. Skompiluj i uruchom aplikację.

```bash
dotnet build
dotnet run
