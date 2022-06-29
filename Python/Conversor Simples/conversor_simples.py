import PySimpleGUI as sg

layout = [
    [
        sg.Input(key = '-INPUT-'), 
        sg.Spin(['km para m', 'kg para g', 'sec para min'], key = '-UNITS-'), 
        sg.Button('Corverter', key = '-CONVERT-')
    ],
    [sg.Text('Output', key = '-OUTPUT-')]
]

window = sg.Window('Converter', layout)

while True:
    event, values = window.read()

    if event == sg.WIN_CLOSED:
        break
    
    if event == '-CONVERT-':
        input_value = values['-INPUT-']
        if input_value.isnumeric():
            match values['-UNITS-']:
                case 'km para m':
                    output = round(float(input_value) * 1000, 2)
                    output_string = f'{input_value} kilometros é igual a {output} metros.'
                case 'kg para g':
                    output = round(float(input_value) * 1000, 2)
                    output_string = f'{input_value} kilogramas é igual a {output} gramas.'
                case 'sec para min':
                    output = round(float(input_value) / 60, 2)
                    output_string = f'{input_value} segundos é igual a {output} minutos.'

            window['-OUTPUT-'].update(output_string)
        else:
            window['-OUTPUT-'].update('Insira um valor numérico válido')

window.close()