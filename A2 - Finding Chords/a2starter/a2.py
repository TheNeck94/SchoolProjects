import sys
import FileUtils as FUtils

FirstSetOfNotes = "part1.txt"
testerNotesPart1 = FUtils.readIntoList(FirstSetOfNotes)
SecondSetOfNotes = "part2.txt"
testerNotesPart2 = FUtils.readIntoList(SecondSetOfNotes)
ThirdSetOfNotes = "part3.txt"
testerNotesPart3 = FUtils.readIntoList(ThirdSetOfNotes)
FourthSetOfNotes = "part4.txt"
testerNotesPart4 = FUtils.readIntoList(FourthSetOfNotes)

orderedNotes = {"Ab": 0,"A": 1,"A#": 2,"Bb": 2,"B": 3,"C": 4,"C#": 5,"Db": 5,"D": 6,"D#": 7,"Eb": 7,"E": 8,"F": 9,"F#": 10,"Gb": 10,"G": 11,"G#": 0}
def getNoteIndex(note):
    return orderedNotes[note]

def checkForMajor(n1,n2,n3):
    flag = False
    if((n1 + 4)%12 == n2 and (n2 + 3)%12 == n3):
        flag = True
        return [flag, 0]
    elif((n3 + 4)%12 == n1 and (n1 + 3)%12 == n2):
        flag = True
        return [flag, 2]
    elif((n2 + 4)%12 == n3 and (n3 + 3)%12 == n1):
        flag = True
        return [flag, 1]
    else:
        return [flag, 4]
    

def checkForMinor(n1,n2,n3):
    flag = False
    if((n1 + 3)%12 == n2 and (n2 + 4)%12 == n3):
        flag = True
        return [flag, 0]
    elif((n3 + 3)%12 == n1 and (n1 + 4)%12 == n2):
        flag = True
        return [flag, 2]
    elif((n2 + 3)%12 == n3 and (n3 + 4)%12 == n1):
        flag = True
        return [flag, 1]
    else:
        return [flag, 4]

def getLetterNames(L):
    letters = []
    for key in L:
        letters.append(key)
    return letters

def getNoteValues(H):
    values = []
    for key in H:
        values.append(key)
    return values

def sortNotes(notes):
    n = {}
    for i in notes:
        n[i] = getNoteIndex(i)
    sortedV = sorted(n.items(), key=lambda x:x[1])
    dictConversion = dict(sortedV)
    inverse = {v: k for k, v in dictConversion.items()}
    return [dictConversion, inverse]

def determineChord(notes):
    k = ",".join(notes.split())
    n1 = k.split(',')[0].capitalize()
    n2 = k.split(',')[1].capitalize()
    n3 = k.split(',')[2].capitalize()
    nX = [n1, n2, n3]
    sN = sortNotes(nX)
    sNnotes = sN[0]
    sNnames = sN[1]
    letters = getLetterNames(sNnames)
    values = getNoteValues(sNnotes)
    result = ""
    majorCheck = checkForMajor(getNoteIndex(values[0]), getNoteIndex(values[1]), getNoteIndex(values[2]))
    minorCheck = checkForMinor(getNoteIndex(values[0]), getNoteIndex(values[1]), getNoteIndex(values[2]))
    
    if(majorCheck[0] == True):
        x = values[majorCheck[1]]
        result = str(x) + " Major"
        print(result)
        return result
    elif(minorCheck[0] == True):
        e = values[minorCheck[1]]
        result = str(e) + " Minor"
        print(result)
        return result
    else:
        result = "NO CHORD"
        print(result)
        return result
    



# determineChord(testerNotesPart4[2])
for i in testerNotesPart4:
    determineChord(i)
