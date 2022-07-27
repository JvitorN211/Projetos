const pokemonName = document.querySelector('.pokemon_name');
const pokemonNumber = document.querySelector('.pokemon_number');
const pokemonImage = document.querySelector('.pokemon_image');
const pokemonAbilities = document.querySelector('.pokemon_abilities');
const baseExperience = document.querySelector('.base_experience');
const firstType = document.querySelector('.first_type');
const secondType = document.querySelector('.second_type');
const pokemonHeight = document.querySelector('.pokemon_height')
const pokemonIcon = document.querySelector('.pokemon_icon');

const form = document.querySelector('.form');
const input = document.querySelector('.input_search');

const buttonNext = document.querySelector('.btn-next');
const buttonPrev = document.querySelector('.btn-prev');
const buttonMale = document.querySelector('.male');
const buttonFemale = document.querySelector('.female');
const buttonShiny = document.querySelector('.btn-shiny');

let searchPokemon = 1;
let stylePokemon = 0;
let shiny = 0;

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
    pokemonAbilities.innerHTML = '';
    baseExperience.innerHTML = '';
    firstType.innerHTML = '';
    secondType.innerHTML = '';
    pokemonHeight.innerHTML = '';

    const data = await fetchPokemon(pokemon);

    if (data) {
        pokemonImage.style.display = 'block';
        pokemonIcon.style.display = 'block';
        pokemonName.innerHTML = data.name;
        pokemonNumber.innerHTML = data.id;
        if (data.id < 650 && stylePokemon == 0 && shiny == 0) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_default'];
            searchPokemon = data.id;
        } else if (data.id < 650 && stylePokemon == 0 && shiny == 1) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_shiny'];
            searchPokemon = data.id;
        } else if (data.id < 650 && stylePokemon == 1 && shiny == 0 && data['sprites']['versions']['generation-v']['black-white']['animated']['front_female'] !== null) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_female'];
            searchPokemon = data.id;
        } else if (data.id < 650 && stylePokemon == 1 && shiny == 1 && data['sprites']['versions']['generation-v']['black-white']['animated']['front_female'] !== null) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_shiny_female'];
            searchPokemon = data.id;
        } else if (data.id < 650 && stylePokemon == 1 && shiny == 0 && data['sprites']['versions']['generation-v']['black-white']['animated']['front_female'] == null) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_default'];
            searchPokemon = data.id;
        } else if (data.id < 650 && stylePokemon == 1 && shiny == 1 && data['sprites']['versions']['generation-v']['black-white']['animated']['front_female'] == null) {
            pokemonImage.src = data['sprites']['versions']['generation-v']['black-white']['animated']['front_shiny'];
            searchPokemon = data.id;
        } else if (data.id > 649){
            pokemonImage.src = data['sprites']['versions']['generation-viii']['icons']['front_default'];
        }
        pokemonAbilities.innerHTML = 'First Ability: ' + data['abilities']['0']['ability']['name'];
        baseExperience.innerHTML = 'Base Experience: ' + data.base_experience;
        firstType.innerHTML = 'First Type: ' + data['types']['0']['type']['name'];
        if (!data['types']['1'] == '') {
            secondType.innerHTML = 'Second Type: ' + data['types']['1']['type']['name'];
            secondType.style.display = 'block';
        } else {
            secondType.style.display = 'none';
        }
        pokemonHeight.innerHTML = 'Height: ' + data.height / 10 + 'm';
        pokemonIcon.src = data['sprites']['versions']['generation-viii']['icons']['front_default'];
        input.value = '';
        searchPokemon = data.id;
    } else {
        pokemonImage.style.display = 'none';
        pokemonIcon.style.display = 'none';
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

buttonMale.addEventListener('click', () => {
    stylePokemon = 0;
    renderPokemon(searchPokemon);
})

buttonFemale.addEventListener('click', () => {
    stylePokemon = 1;
    renderPokemon(searchPokemon);
})

buttonShiny.addEventListener('click', () => {
    if(shiny !== 1) {
        shiny = 1;
        buttonShiny.innerHTML = 'Normal';
    } else if (shiny == 1) {
        shiny = 0;
        buttonShiny.innerHTML = 'Shiny';
    }
    renderPokemon(searchPokemon);
})

renderPokemon(searchPokemon);