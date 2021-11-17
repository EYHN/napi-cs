const b = require('benny')

const aotPath = process.argv[2]
const clrPath = process.argv[3]

const aot = require(aotPath)
const clr = require(clrPath)

function plusJavascript(a, b) {
  return a + b
}

function addJavascript(a) {
  return (b) => a + b
}

b.suite(
  'Plus number',
  b.add('napi-cs (CLR)', () => {
    clr.plus(1, 100)
  }),
  b.add('napi-cs (AOT)', () => {
    aot.plus(1, 100)
  }),
  b.add('JavaScript', () => {
    plusJavascript(1, 100)
  }),

  b.cycle(),
  b.complete()
)

b.suite(
  'Currying',
  b.add('napi-cs (CLR)', () => {
    clr.add("hello")("world")
  }),
  b.add('napi-cs (AOT)', () => {
    aot.add("hello")("world")
  }),
  b.add('JavaScript', () => {
    addJavascript("hello")("world")
  }),

  b.cycle(),
  b.complete()
)
