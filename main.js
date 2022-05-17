const {argv: args} = process
    , {readdir} = require('fs/promises')
    , path = require('path');

(async () => {
    const cmdPath = path.join(__dirname, 'utils')
        , files = await readdir(cmdPath)
        , commands = files.map(file => file.replace('.js', ''))

    if (args.length <= 2) {
        console.error('Expects at least one argument')
        process.exit(1)
        return
    }

    const command = args[2]

    if (!commands.includes(command)) {
        console.error(`Expects valid commands: ${commands.join(", ")}`)
        process.exit(1)
        return
    }

    require(`./utils/${command}`)(args)
})()