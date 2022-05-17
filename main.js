const {argv: args, exit} = process
    , {readdir} = require('fs/promises')
    , path = require('path');

(async () => {
    const cmdPath = path.join(__dirname, 'utils')
        , files = await readdir(cmdPath)
        , commands = files.map(file => file.replace('.js', ''))

    if (args.length <= 2) {
        console.error('Expects at least one argument')
        exit(1)
        return
    }

    const command = args[2]

    if (!commands.includes(command)) {
        console.error(`Expects valid commands: ${commands.join(", ")}`)
        exit(1)
        return
    }

    try {
        const result = await require(`./utils/${command}`)(args)
        if (!!result)
            console.log(result)
    } catch (err) {
        console.error(err)
        exit(1)
    }
})()