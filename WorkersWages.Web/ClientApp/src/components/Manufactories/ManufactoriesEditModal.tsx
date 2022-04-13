import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { ManufactoryEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { ManufactoriesEditForm } from './ManufactoriesEditForm';

interface Props {
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const ManufactoriesEditModal = (props: Props) => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [manufactoryInfo, setManufacoryInfo] = useState<ManufactoryEditRequest>();
    useEffect(() => {
        if (!id) return;

        apiClient.manufactoriesDetails(+id).then((r) => setManufacoryInfo(
            new ManufactoryEditRequest({
                name: r.name,
                number: r.number,
                headFIO: r.headFIO
            })
        ));
    }, [id])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: ManufactoryEditRequest) => {
        if (!id) return;

        await apiClient.manufactoriesEdit(+id, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [id, history, propsOnDataChanged]);

    if (!manufactoryInfo) return null;

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование цеха">
            <ManufactoriesEditForm onSubmit={handleSubmit} data={manufactoryInfo} />
        </AisModal>
    );
};

ManufactoriesEditModal.displayName = 'ManufactoriesEditModal';
