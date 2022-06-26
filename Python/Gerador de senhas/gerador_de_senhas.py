import random

lower_case = "abcdefghijklmnopqrstuvwxyz"
upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
number = "0123456789"
symbols = "!@#$%¨&*()<>,.\|-_*/+=[]}{"

Use_for = lower_case + upper_case + number + symbols 
length_for_pass = 9

password = "".join(random.sample(Use_for, length_for_pass))

print("Sua senha gerada via Python é: " + password)