# Pokemon Info Fetcher

### Introduction 
This a very simple application that allows you to easily get information about Pokemon and their most up to date competitive moveset (according to Smogon) as well as information about their types, breading, etc..  
**Objective**:  
The goal here isn't doing anything super fancy, just making something simple that saves us from endless scrolls and researches by having a good chunk of information in a single place.  

### Functionalities (for the time being):
It basically merges information gattered from smogon HTML (weirdly contains a json with tons of information about everything) and information from the Poke API using the wrapper nugget [PokeApi.NET](https://gitlab.com/PoroCYon/PokeApi.NET).  
This information is displayed very simple in the console to the user.  

### The Future
This is a very simple project for the moment, merging the informations and will return a simple output to the user, a simple interface using Windows Forms is planned for the future tho...  

Also in the future we plan on introducing support for information about berries, abilities, etc.. making a powerfull and condensed utility tool that has usefull information in a single place.  

### How do I use it??
If you have [Visual Studio](https://visualstudio.microsoft.com/) (or anything similar) you can just run the project by pressing f5 or ctrl+f5, if you don't you can download the zip of the project or clone it(from github), go to the bin folder and run the executable file (PokemonInfoFetcher.exe).  
In case you're just using the bin you just need to click on the PokemonInfoFetcher.exe file.  
After the aplication starts simply type the name or number of the pokemon you wish to get information for, and if everything goes well the info should be displayed, in case one of the sources (PokeAPI or Smogon) does not have information about the pokemon a message will appear identifying the source, but the information that was possible to gather will be displayed.  