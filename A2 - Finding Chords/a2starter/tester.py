import sys
import FileUtils
from a2 import determineChord


def runTests(cases, answers):
    if len(cases) != len(answers):
        print("ERROR: there must be one answer for each case!")
        return

    passed = 0
    failed = 0
    for i in range(len(cases)):
        case = cases[i]
        expected = answers[i]
        actual = determineChord(case)
        if expected == actual:
            passed += 1
        else:
            failed += 1
            if len(sys.argv) == 2 and sys.argv[1] == "showFailures":
                print("{"+case+"}", "Expected " +
                      expected + "; found " + actual)

    return [passed, failed]


print()
print("A2 Testing")
print()
cases = FileUtils.readIntoList("chords.txt")
answers = FileUtils.readIntoList("chords-answers.txt")
results = runTests(cases, answers)
print("  Chord Expected ({:,} cases)".format(len(cases)))
print("    Passed: {:,}".format(results[0]))
print("    Failed: {:,}".format(results[1]))
print()
cases = FileUtils.readIntoList("nochords.txt")
answers = []
for c in cases:
    answers.append("NO CHORD")
results = runTests(cases, answers)
print("  No Chord Expected ({:,} cases)".format(len(cases)))
print("    Passed: {:,}".format(results[0]))
print("    Failed: {:,}".format(results[1]))
