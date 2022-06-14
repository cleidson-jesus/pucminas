export const isoDateToLocale = (date: string) => {
    if (!date) {
        return "";
    }
    return new Date(date).toLocaleDateString("pt-br")
}

export const localeDateToIsoString = (date: string) => {
    if (!date) {
        return "";
    }
    const [day, month, year] = date.split("/");
    return new Date(`${month}-${day}-${year}`).toISOString();
}