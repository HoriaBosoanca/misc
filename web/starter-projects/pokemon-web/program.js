let pokemonName;
function search(){
    pokemonName = document.getElementById("input").value.toLowerCase()
    fetch("https://pokeapi.co/api/v2/pokemon/" + pokemonName)
        .then(response => {
            if(!response.ok){
                throw new Error("Api works, but this pokemon was not found.")
            }
            return response.json()
        })
        .then(data => {
            console.log(data)
            let spriteURL = data.sprites.front_default
            let imageElement = document.getElementById("image")
            imageElement.src = spriteURL
        })
        .catch(error => console.error(error))
}
