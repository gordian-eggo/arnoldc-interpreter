# TO DO
# if statement to see if file exists or not
def load_file(file):
    string = ""
    file_handle = open(file, "r")
    for line in file_handle:
        string = string + " " + line

    return string