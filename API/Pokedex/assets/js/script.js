const pokemonName = document.querySelector('.pokemon_name');
const pokemonNumber = document.querySelector('.pokemon_number');
const pokemonImage = document.querySelector('.pokemon_image');

const form = document.querySelector('.form');
const input = document.querySelector('.input_search');

const buttonNext = document.querySelector('.btn-next');
const buttonPrev = document.querySelector('.btn-prev');

let searchPokemon = 1;

const fetchPokemon = async (pokemon) => {
    const APIResponse = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemon}`);
    // console.log(APIResponse);

    if (APIResponse.status == 200) {
        const data = await APIResponse.json();
        return data;
    }

    // console.log(data);
}
// fetchPokemon('25');

const renderPokemon = async (pokemon) => {

    pokemonName.innerHTML = 'Loading...';
    pokemonNumber.innerHTML = '';

    const data = await fetchPokemon(pokemon);

    if (data) {
        pokemonImage.style.display = 'block';
        pokemonName.innerHTML = data.name;
        pokemonNumber.innerHTML = data.id;
        pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_default']
        input.value = '';
        searchPokemon = data.id;
    } else {
        pokemonImage.style.display = 'none';
        pokemonName.innerHTML = 'Not found';
        pokemonNumber.innerHTML = '000';
    }
    
    // pokemonIcon.src = data['sprites']['versions']['generation-viii']['icons']['front_default']

    // console.log(data);
}
// renderPokemon('150');

form.addEventListener('submit', (event) => {
    event.preventDefault();
    renderPokemon(input.value.toLowerCase());
    // console.log('enviando formulário...')
})

buttonPrev.addEventListener('click', () => {
    if (searchPokemon > 1) {
        searchPokemon --;
        renderPokemon(searchPokemon);
    }
    // alert('prev clicked')
})

buttonNext.addEventListener('click', () => {
    searchPokemon ++;
    renderPokemon(searchPokemon);
    // alert('next clicked')
})

renderPokemon(searchPokemon);