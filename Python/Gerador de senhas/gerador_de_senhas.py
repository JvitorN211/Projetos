import random
import PySimpleGUI as sg
import pyperclip as pc

layout = [
    [sg.Text('Escolha um número de caracteres para sua senha:')],
    [sg.Input(key = '-INPUT-'), sg.Button('Gerar', key = '-GERAR-')],
    [sg.Text('Senha', key = '-SENHA-'), sg.Button('Copiar', key = '-COPIAR-'), sg.Text('status', key = '-STATUS-')]
]

window = sg.Window('Gerador de Senhas', layout)

lower_case = "abcdefghijklmnopqrstuvwxyz"
upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
number = "0123456789"
symbols = "!@#$%¨&*()<>,.\|-_*/+=[]}{"

Use_for = lower_case + upper_case + number + symbols 
length_for_pass = 0

while True:
    event, values = window.read()

    if event == sg.WIN_CLOSED:
        break
    
    if event == '-GERAR-':
        input_value = values['-INPUT-']
        if input_value.isnumeric():
            length_for_pass = int(input_value)
            password = "".join(random.sample(Use_for, length_for_pass))
            window['-SENHA-'].update("Sua senha gerada por Python é: " + password)
        else:
            window['-STATUS-'].update("Insira um valor numérico!")
        

    if event == '-COPIAR-':
        pc.copy(password)
        window['-STATUS-'].update("copiado")